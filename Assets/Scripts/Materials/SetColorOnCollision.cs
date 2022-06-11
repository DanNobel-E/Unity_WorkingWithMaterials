using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColorOnCollision : MonoBehaviour
{
    MeshRenderer mr;
    Material m;

    private void Start()
    {
        mr = GetComponent<MeshRenderer>();
        m = mr.sharedMaterial;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
            mr.sharedMaterial = m;
    }

    private void OnCollisionEnter(Collision collision)
    {
        SphereMovement s;
        if(collision.gameObject.TryGetComponent<SphereMovement>(out s))
            mr.sharedMaterial = collision.gameObject.GetComponent<MeshRenderer>().sharedMaterial;
    }
}
