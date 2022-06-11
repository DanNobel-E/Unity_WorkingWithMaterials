using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Painter : MonoBehaviour
{
    public Camera Cam;
    public Texture2D DefaultBrush;
    public RenderTexture RT;
    public Texture2D ClearedT;
    public RectTransform SizeSliderLabel;

    TextMeshProUGUI sizeLabelText;

    Texture2D currentBrush;
    int brushSize;
    

    Color currentColor;
    RaycastHit hitInfo;

    // Start is called before the first frame update
    void Start()
    {
        if (DefaultBrush != null)
        {
            currentBrush = DefaultBrush;
            brushSize = currentBrush.width;

        }

        sizeLabelText = SizeSliderLabel.GetComponentInChildren<TextMeshProUGUI>();
     }

    private void OnEnable()
    {
        PaletteColorPicker.OnPickColor.AddListener(SetBrushColor);
    }

    private void OnDisable()
    {
        PaletteColorPicker.OnPickColor.RemoveListener(SetBrushColor);

    }
    
    void Update()
    {
        if (Input.GetMouseButton(0))
        {

            if (Cam == null)
                return;

            Ray ray = Cam.ScreenPointToRay(Input.mousePosition);
            

            if (Physics.Raycast(ray, out hitInfo))
            {
                if(hitInfo.collider is MeshCollider)
                {
                    RenderTexture.active = RT;
                    GL.PushMatrix();
                    GL.LoadPixelMatrix(0, RT.width,0,RT.height);

                    int posX = (int)(RT.width * hitInfo.textureCoord.x) - (brushSize / 2);
                    int posY = (int)(RT.height * hitInfo.textureCoord.y) - (brushSize / 2);


                    Rect r = new Rect(posX, posY, brushSize, brushSize);

                    Graphics.DrawTexture(r, currentBrush);
                    GL.PopMatrix();
                    RenderTexture.active = null;
                }



            }


        }
    }

    public void Resize(float size)
    {
        brushSize = (int)size;
    }

   

    public void OnClear()
    {
        RenderTexture.active = RT;
        GL.PushMatrix();
        GL.LoadPixelMatrix(0, RT.width, 0, RT.height);

       
        Rect r = new Rect(0, 0, RT.width, RT.height);

        Graphics.DrawTexture(r,ClearedT);
        GL.PopMatrix();
        RenderTexture.active = null;
    }

    public void OnBucket(Texture2D t)
    {
        RenderTexture.active = RT;
        GL.PushMatrix();
        GL.LoadPixelMatrix(0, RT.width, 0, RT.height);


        Rect r = new Rect(0, 0, RT.width, RT.height);

        Graphics.DrawTexture(r, t);
        GL.PopMatrix();
        RenderTexture.active = null;
    }

    public void SetBrushColor(Color c)
    {
        currentColor = c;

        if (currentBrush != null)
        {


            for (int x = 0; x < currentBrush.width; x++)
            {
                for (int y = 0; y < currentBrush.height; y++)
                {
                    Color brushColor = currentBrush.GetPixel(x, y);
                    if (brushColor.a != 0)
                    {
                       
                        Color currentAlpha = new Color(c.r, c.g, c.b, brushColor.a);
                        currentBrush.SetPixel(x, y, currentAlpha);
                        currentBrush.Apply();

                    }
                }
            }
        }
    }
    public void SetNewBrush(Texture2D texture)
    {
       
        SetBrushColor(Color.white);
        currentBrush = texture;

    }

    public void SizeSlideLabel()
    {
        SlideLabel(SizeSliderLabel, sizeLabelText, brushSize);

    }

    public void SlideLabel(RectTransform rect, TextMeshProUGUI text, int value)
    {
        if (!rect.gameObject.activeSelf)
            rect.gameObject.SetActive(true);
        Vector2 mousePos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)rect.parent, Input.mousePosition, null, out mousePos);
        if (mousePos.x + 95 >= 0 && mousePos.x + 95 <= 200)
        {

            rect.anchoredPosition = new Vector2(mousePos.x + 95, SizeSliderLabel.anchoredPosition.y);
            text.text = value.ToString();
        }
        else
            rect.gameObject.SetActive(false);
    }

  

    public void OnSizeSlideEnd()
    {
        SizeSliderLabel.gameObject.SetActive(false);
    }
}
