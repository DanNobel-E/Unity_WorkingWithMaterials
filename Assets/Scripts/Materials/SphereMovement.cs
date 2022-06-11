using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMovement : MonoBehaviour
{
    Rigidbody rb;
    public float Velocity;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * Velocity;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = rb.velocity.normalized * Velocity;

    }
}
