using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum BrushMode { Brush, Bucket}
public class Brush : MonoBehaviour, IPointerClickHandler
{
    public Painter Painter;
    public BrushMode Mode;
    Texture2D texture;

    private void Start()
    {
        texture = (Texture2D)GetComponent<RawImage>().texture;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        switch (Mode)
        {
            case BrushMode.Brush:
                Painter.SetNewBrush(texture);
                break;
            case BrushMode.Bucket:
                Painter.OnBucket(texture);
                break;
        }
    }

   
}
