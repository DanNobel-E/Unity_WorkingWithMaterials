using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SpriteQuadWriter : MonoBehaviour
{
    public Texture2D Source, Original;
    [Range(0,1)]
    public float UVTopLeftX, UVTopLeftY, UVBottomRightX, UVBottomRightY;
    public Color QuadColor;
    public bool Write;
    public bool RealTime;
    private bool writeT;

    void Update()
    {
        if (Write || RealTime)
        {
            for (int y = 0; y < Source.height; y++)
            {
                if (y <= UVTopLeftY * Source.height && y >= UVBottomRightY * Source.height)
                    writeT = true;


                    for (int x = 0; x < Source.width; x++)
                    {
                        if (x >= UVTopLeftX * Source.width && x <= UVBottomRightX * Source.width && writeT)
                        {
                            Source.SetPixel(x, y, QuadColor);

                        }
                        else
                        {
                            Source.SetPixel(x, y, Original.GetPixel(x, y));

                        }

                        Source.Apply();
                    }


                writeT = false;
            }

            Write = false;
        }
    }
}
