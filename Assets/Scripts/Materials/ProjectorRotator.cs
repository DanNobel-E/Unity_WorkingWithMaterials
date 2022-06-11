using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectorRotator : MonoBehaviour
{
    RaycastHit hitInfo;
    Ray customRay;
    public float maxDistance = 5;
    public Camera cam;

    void Update()
    {
        customRay = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(customRay, out hitInfo, maxDistance))
        {
            Debug.DrawLine(transform.position, hitInfo.point, Color.green);
            transform.LookAt(hitInfo.point);
        }

    }
}
