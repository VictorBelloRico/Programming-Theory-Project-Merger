using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class GridManager : MonoBehaviour
{
    private int witdh = 4;
    private int height = 4;
    [SerializeField] private Tile tilePrefab;
    [SerializeField] private Transform cam;

    private List<Vector2> FullTiles = new List<Vector2>();
    private List<Vector2> EmptyTiles = new List<Vector2>();
    [SerializeField] List<GameObject> items;

    public static GridManager Instance { get; private set; }

    public Color TeamColor;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        GenerateGrid();
        InvokeRepeating("SpawnItem", 1.0f, 1.0f);
    }

    void GenerateGrid()
    {
        for (int x = 0; x < witdh; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var spawnnedTile = Instantiate(tilePrefab, new Vector3(x, y), Quaternion.identity);
                spawnnedTile.name = $"Tile {x} {y}";

                var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                spawnnedTile.Init(isOffset);

                EmptyTiles.Add(new Vector2(x, y));
            }
        }
        cam.transform.position = new Vector3((float)witdh / 2 - 0.5f, (float)height / 2 - 0.5f, -10);
    }
    void SpawnItem()
    {
        if (EmptyTiles.Count == 0)
        {
            //Exit();
            Debug.Log("Ahora me habría cerrado");
        }
        else
        {
            int RandomTileIdx = Random.Range(0, EmptyTiles.Count);
            int randomItemIdx = Random.Range(0, items.Count);
            Instantiate(items[randomItemIdx], EmptyTiles[RandomTileIdx], Quaternion.identity);
            FullTiles.Add(EmptyTiles[RandomTileIdx]);
            EmptyTiles.Remove(EmptyTiles[RandomTileIdx]);

        }
    }
    public void LiberateGridTile(Vector2 tile)
    {
        FullTiles.Remove(tile);
        EmptyTiles.Add(tile);
    }

    public void LiberateGridTile(Vector2 tile1, Vector2 tile2)
    {
        FullTiles.Remove(tile1);
        EmptyTiles.Add(tile1);

        FullTiles.Remove(tile2);
        EmptyTiles.Add(tile2);
    }
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
