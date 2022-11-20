using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleLvl1 : Draggable
{
    public override void Merge(Vector3 instantiatePosition,  Vector3 liberatePosition)
    {
        Instantiate(Resources.Load("CircleLvl2_Object"), instantiatePosition, Quaternion.identity);
        GridManager.Instance.LiberateGridTile(liberatePosition);
    }
}
