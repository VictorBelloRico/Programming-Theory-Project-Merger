using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleLvl3 : Draggable
{
    private int score = 10;
    public override void Merge(Vector3 liberatePosition1, Vector3 liberatePosition2)
    {
        Instantiate(Resources.Load("FloatingTextObj"), transform.position, Quaternion.identity);
        GridManager.Instance.LiberateGridTile(liberatePosition1, liberatePosition2);
        GameManager.Instance.UpdateScore(score);
        GameManager.Instance.time += 5;
    }
}
