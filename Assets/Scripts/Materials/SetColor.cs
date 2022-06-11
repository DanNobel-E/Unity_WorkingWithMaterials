using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SetColor : MonoBehaviour, IPointerDownHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    MeshRenderer meshRenderer;
    Color defaultColor;


    public void OnPointerClick(PointerEventData eventData)
    {
   
    }

    private void OnEnable()
    {
        ColorManager.ClearAll.AddListener(Clear);

    }

    private void OnDisable()
    {
        ColorManager.ClearAll.RemoveListener(Clear);

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //if (eventData.button == PointerEventData.InputButton.Left)
        //    meshRenderer.material.color = ColorManager.CurrentColor;
    }

    public void OnSetColor()
    {
       meshRenderer.material.color = ColorManager.CurrentColor;
    }

    public void Clear()
    {
        meshRenderer.material.color = defaultColor;
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
        defaultColor = meshRenderer.material.color;
    }

}
