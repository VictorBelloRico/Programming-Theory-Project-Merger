using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class GridManager : MonoBehaviour
{
    [SerializeField] private int witdh, height;
    [SerializeField] private Tile tilePrefab;
    [SerializeField] private Transform cam;

    //private Dictionary<Vector2, Tile> tiles;
    public Dictionary<Vector2, bool> emptyTiles;

    public List<GameObject> items;

    private bool isGameActive;
    public int freeTilesCount = 16;

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
        isGameActive = true;
        GenerateGrid();
        StartCoroutine(SpawnItem());
    }

    private void Update()
    {
        if (freeTilesCount == 0)
        {
            Exit();
        }
    }
    void GenerateGrid()
    {
        //tiles = new Dictionary<Vector2, Tile>();
        emptyTiles = new Dictionary<Vector2, bool>();
        for (int x = 0; x < witdh; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var spawnnedTile = Instantiate(tilePrefab, new Vector3(x, y), Quaternion.identity);
                spawnnedTile.name = $"Tile {x} {y}";

                var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                spawnnedTile.Init(isOffset);

                emptyTiles[new Vector2(x, y)] = true;
                //tiles[new Vector2(x, y)] = spawnnedTile;
            }

        }
        cam.transform.position = new Vector3((float)witdh / 2 - 0.5f, (float)height / 2 - 0.5f, -10);
    }

    public bool IsTileEmpty(Vector2 pos)
    {
        if (emptyTiles.TryGetValue(pos, out var isEmpty))
        {
            return isEmpty;
        }
        return false;

    }


    /*empezar corrutina de instatiate
    cada x segundos:
        -Obtener una x,y en random.range(4)
        -Comprobar si la tile correspondiente está vacía
            -Si está vacía, generar un item
            -Si no está vacía, buscar otra
    */

    IEnumerator SpawnItem()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(2);
            bool keepSearching = true;
            while (keepSearching)
            {
                var randomTile = GenerateRandomTile();
                if (IsTileEmpty(randomTile))
                {
                    int index = Random.Range(0, items.Count);
                    Instantiate(items[index], randomTile, Quaternion.identity);
                    emptyTiles[randomTile] = false;
                    keepSearching = false;
                    freeTilesCount -= 1;
                }
            }

        }

    }

    public Vector2 GenerateRandomTile()
    {
        var x = Random.Range(0, 4);
        var y = Random.Range(0, 4);
        return new Vector2(x, y);
    }

    /*Create 2 forms of LiberateGirdTile:
     *  -One wit 1 Vector2 parameter, to liberate 1 tile when Lvl1 are merged
     *  -The other with 2 Vector2 parameter, to liberate 2 tiles when Lvl2 are merged
     *  -Hay que enviar las posiciones desde el propio script de cada item
      
     
     */
    public void LiberateGridTile(Vector2 pos)
    {
        emptyTiles[pos] = true;
        freeTilesCount += 1;
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
