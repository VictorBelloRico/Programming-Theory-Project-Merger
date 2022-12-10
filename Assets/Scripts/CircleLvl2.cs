using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleLvl2 : Draggable
{
    private int score = 5;
    public override void Merge(Vector3 instantiatePosition, Vector3 liberatePosition)
    {
        Instantiate(Resources.Load("CircleLvl3_Object"), instantiatePosition, Quaternion.identity);
        GridManager.Instance.LiberateGridTile(liberatePosition);
        GameManager.Instance.UpdateScore(score);
    }
}
