using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnPickColor : UnityEvent<Color> { }
public class PaletteColorPicker : MonoBehaviour, IPointerClickHandler
{
    public Camera Cam;
    public static OnPickColor OnPickColor= new OnPickColor();
    RawImage raw;

    void Start()
    {
       
        raw = GetComponent<RawImage>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Vector2 point;
        Rect r = raw.rectTransform.rect;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(raw.rectTransform, Input.mousePosition, null, out point);

        int px = Mathf.Clamp(0, (int)(((point.x - r.x) * raw.texture.width) / r.width), raw.texture.width);
        int py = Mathf.Clamp(0, (int)(((point.y - r.y) * raw.texture.height) / r.height), raw.texture.height);




        Color c = ((Texture2D)raw.texture).GetPixel((int)px, (int)py);
        OnPickColor.Invoke(c);


    }

   
}
