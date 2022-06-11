using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawTexture : MonoBehaviour
{
    //BottomLeftCoords
    public Vector2 RectBL;
    //WidthHeight
    public Vector2 RectSize;
    public RenderTexture DrawOnThisRT;
    public Texture2D TextureToDraw;
    public bool ClearRT;
    public bool Draw;
    public bool UsePixelMatrix;

    public void Clear()
    {
        RenderTexture.active = DrawOnThisRT;
        GL.Clear(true, true, Color.black);
        RenderTexture.active = null;
    }

    private void Update()
    {
        
        if (ClearRT)
        {
            ClearRT = false;
            Clear();
        }

        if (!Draw) return;
        Draw = false;

        //Activate the render texture
        RenderTexture.active = DrawOnThisRT;

        //Work in the pixel matrix of the texture resolution.
        GL.PushMatrix();

        //DrawTexture Rect coords depends on the Matrix used
        if (UsePixelMatrix)
        {
            // LoadPixelMatrix takes 4 parameters: left, right, bottom, top
            //  (0,1,0,1) is the same as GL.LoadOrtho();
            GL.LoadPixelMatrix(0, DrawOnThisRT.width, 0, DrawOnThisRT.height);
        }
        else
        {
            // 0,0 is the bottom left corner and 1,1 the top right
            GL.LoadOrtho();
        }

        //Paint the desired texture onto the desired coordinates with the desired size.
        //the "hit" variable is the RaycastHit
        Graphics.DrawTexture(new Rect(RectBL.x, RectBL.y, RectSize.x, RectSize.y), TextureToDraw);
        //Revert the matrix and active render texture.
        GL.PopMatrix();
        RenderTexture.active = null;
    }
}
