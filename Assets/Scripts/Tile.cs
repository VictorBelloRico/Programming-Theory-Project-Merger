using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color baseColor, offsetColor;
    [SerializeField] private SpriteRenderer myRenderer;

    public void Init(bool isOffset)
    {
        if (isOffset)
        {
            myRenderer.color = offsetColor;
        }
        else
        {
            myRenderer.color = baseColor;
        }
    }
    private void Update()
    {
        if (!GameManager.Instance.isGameActive)
        {
            Destroy(gameObject);
        }
    }
}
