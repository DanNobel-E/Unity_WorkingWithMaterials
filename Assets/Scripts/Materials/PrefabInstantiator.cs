using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabInstantiator : MonoBehaviour
{
    public Transform Center;
    public GameObject Prefab;
    public Material[] Materials;
    public int Num;
    public float Radius;
    public float MinVelocity;
    public float MaxVelocity;


    void Start()
    {
        for (int i = 0; i < Num; i++)
        {
            GameObject go = Instantiate(Prefab, Center);
            Vector2 pos = Random.insideUnitCircle*Radius;
            Vector3 pos3D = new Vector3(transform.position.x+ pos.x, go.transform.position.y, transform.position.z+ pos.y);
            go.transform.position = pos3D;
            go.GetComponent<MeshRenderer>().sharedMaterial = Materials[Random.Range(0, Materials.Length)];
            go.GetComponent<SphereMovement>().Velocity = Random.Range(MinVelocity, MaxVelocity);
        }
    }

   
}
