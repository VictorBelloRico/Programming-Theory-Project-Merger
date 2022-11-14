using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleLvl1 : Draggable
{
    public override void Merge(Vector3 position)
    {
        Instantiate(Resources.Load("TriangleLvl2_Object"), position, Quaternion.identity);
    }
}
