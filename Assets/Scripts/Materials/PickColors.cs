using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class PickColors : MonoBehaviour, IPointerDownHandler,IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler
{
     MeshRenderer meshRenderer;

    public void OnPointerClick(PointerEventData eventData)
    {
        
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
    }

    public void OnPointerExit(PointerEventData eventData)
    {
    }

   
    void Start()
    {
        meshRenderer= GetComponent<MeshRenderer>();

    }


    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Color c = meshRenderer.material.color;
            ColorManager.SetPalette(c);

        }
    }
}
