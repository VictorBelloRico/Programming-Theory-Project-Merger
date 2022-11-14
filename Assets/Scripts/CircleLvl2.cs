using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleLvl2 : Draggable
{
    public override void Merge(Vector3 position)
    {
        Debug.Log("+5 points");
    }
}
