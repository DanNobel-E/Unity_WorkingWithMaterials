using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(SpriteRenderer))]
public class SpriteCloner_Start : MonoBehaviour
{
    
    public Texture2D Source;
    public bool UseSetPixels = false;
    SpriteRenderer SRenderer;

    void Start()
    {
        SRenderer = GetComponent<SpriteRenderer>();
        Texture2D destination = new Texture2D(Source.width, Source.height);

        if (UseSetPixels)
        {
            for (int x = 0; x < Source.width; x++)
            {
                for (int y = 0; y < Source.height; y++)
                {
                    destination.SetPixel(x, y, Source.GetPixel(x, y));

                }
            }
            //Use Get/SetPixel to copy
        }
        else
        {
            Color[] colors = Source.GetPixels(0);
            destination.SetPixels(colors);
            //Use Get/SetPixels to copy
        }

        destination.Apply();
        destination.filterMode=FilterMode.Point;
        SRenderer.sprite = Sprite.Create(destination, new Rect(0, 0, destination.width, destination.height), new Vector2(0.5f, 0.5f));
        //Apply()
        //FilterMode
        //Set Sprite
    }
}
