using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareLvl1 : Draggable
{
    public override void Merge(Vector3 position)
    {
        Instantiate(Resources.Load("SquareLvl2_Object"), position, Quaternion.identity);
    }
}
