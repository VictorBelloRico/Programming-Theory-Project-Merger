using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareLvl2 : Draggable
{
    private int score = 5;
    public override void Merge(Vector3 liberatePosition1, Vector3 liberatePosition2)
    {
        GridManager.Instance.LiberateGridTile(liberatePosition1, liberatePosition2);
        GameManager.Instance.UpdateScore(score);
    }
}
