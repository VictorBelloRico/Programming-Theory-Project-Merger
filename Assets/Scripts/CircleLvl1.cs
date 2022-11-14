using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleLvl1 : Draggable
{
    public override void Merge(Vector3 position)
    {
        Instantiate(Resources.Load("CircleLvl2_Object"), position, Quaternion.identity);
    }
}
