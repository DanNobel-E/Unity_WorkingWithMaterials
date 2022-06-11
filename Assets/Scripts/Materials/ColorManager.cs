using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


[Serializable]


public class ColorManager : MonoBehaviour
{
    public Camera Cam;
    public static Color CurrentColor;
    public GameObject CurrentPalette;
    static GameObject currentPalette;
    public static UnityEvent ClearAll;

    private void Start()
    {
        currentPalette = CurrentPalette;
        ClearAll = new UnityEvent();
    }

    public static void SetPalette(Color c)
    {
        CurrentColor = c;
        currentPalette.GetComponent<MeshRenderer>().material.color = c;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            ClearAll.Invoke();

        }else if (Input.GetMouseButton(0))
        {
            Ray ray = Cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if(Physics.Raycast(ray,out hitInfo))
            {
                SetColor s;
                if(hitInfo.collider.gameObject.TryGetComponent<SetColor>(out s))
                {
                    s.OnSetColor();

                }
            }


        }
    }

  
}
