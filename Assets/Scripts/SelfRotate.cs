using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfRotate : MonoBehaviour
{
    public Vector3 Rotation;
  

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Rotation*Time.deltaTime);
    }
}
