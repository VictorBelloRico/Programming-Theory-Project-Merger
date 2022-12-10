using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{

    private float destroyTime = 1.0f;
    private Rigidbody RB;
    public float force = 10f; 

    void Start()
    {
        Destroy(gameObject, destroyTime);
        RB = GetComponent<Rigidbody>();
        RB.AddForce(Vector3.up* force);
    }
}
