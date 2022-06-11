using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class SpriteZoomer : MonoBehaviour
{
    public Texture2D Source;
    public int ZoomFactor;
    public bool Write;
    SpriteRenderer spriteRenderer;
    Texture2D Result;
    static int textureCounter=0;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Write)
        {
            Result = new Texture2D(Source.width * ZoomFactor, Source.height * ZoomFactor);
            Result.name = "NewTexture";
            int xR = 0;
            int yR = 0;

            for (int y = 0; y < Source.height; y++)
            {

                for (int x = 0; x < Source.width; x++)
                {

                    Color c = Source.GetPixel(x, y);
                    for (int i=0; i < ZoomFactor;i++)
                    {
                        for (int j = 0; j < ZoomFactor; j++)
                        {
                            Result.SetPixel(xR + j, yR + i, c);

                        }

                    }
                   

                    xR += ZoomFactor;



                    Result.Apply();
                }

                xR = 0;
                yR += ZoomFactor;
            }

            File.WriteAllBytes(Application.dataPath + $"/Textures/Scripting/NewTexture{textureCounter}.png", Result.EncodeToPNG());
            textureCounter++;
            AssetDatabase.Refresh();
            
            Sprite s = Sprite.Create(Result, new Rect(0, 0, Result.width, Result.height), new Vector2(0.5f, 0.5f));
            spriteRenderer.sprite = s;
            Write = false;
        }
    }
}
