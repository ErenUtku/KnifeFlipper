using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlicedObstacle : MonoBehaviour
{
    public Rigidbody rb;
    public float smashEffect;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.up * -smashEffect, ForceMode.Impulse);
    }

}
