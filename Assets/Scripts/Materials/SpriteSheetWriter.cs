using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SpriteSheetWriter : MonoBehaviour
{
    public Transform CubesRoot;
    public SpriteRenderer SpriteRenderer;
    public Image SpriteSheetRenderer;
    public Animator Anim;
    public Vector2 FrameSize;
    public float SpriteSheetFPS;
    List<Sprite> sprites = new List<Sprite>();
    private bool spacePressed;
    float timer;
    int frameIndex;
    static int textureCounter;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
            SaveSprite();

        if (Input.GetKeyDown(KeyCode.Space) && sprites.Count!=0)
            OnSpacePressed();

        if (Input.GetKeyDown(KeyCode.E) && sprites.Count != 0)
            SaveSheet();

        if (spacePressed)
            ShowSheet();


    }

    private void SaveSheet()
    {
       
        int cols = sprites.Count/2;
        int rows = sprites.Count/cols;

        Texture2D t = new Texture2D((int)FrameSize.x*cols,(int)FrameSize.y*rows);

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
               Texture2D curr = sprites[row * cols + col].texture;

                for (int y = 0; y < FrameSize.x; y++)
                {
                    for (int x = 0; x < FrameSize.x; x++)
                    {
                        Color c = curr.GetPixel(x, y);
                        t.SetPixel(x+((int)FrameSize.x*col), y+((int)FrameSize.x*row), c);
                        t.Apply();
                    }
                }
            }
        }

        File.WriteAllBytes(Application.dataPath + $"/Textures/SpriteSheets/SpriteSheet{textureCounter}.png", t.EncodeToPNG());
        AssetDatabase.Refresh();
        textureCounter++;
    }

    private void ShowSheet()
    {
        float frameDuration = 1 / SpriteSheetFPS;
        timer += Time.deltaTime;

        if (timer >= frameDuration)
        {
            frameIndex++;

            if (frameIndex >= sprites.Count)
                frameIndex = 0;

            SpriteSheetRenderer.sprite = sprites[frameIndex];
            timer = 0;
        }
    }

    private void OnSpacePressed()
    {
        if (spacePressed)
        {
            spacePressed = false;
            Anim.SetBool("Show", false);
            
        }
        else
        {
            spacePressed = true;
            Anim.SetBool("Show", true);
            frameIndex = 0;
            SpriteSheetRenderer.sprite = sprites[frameIndex];
            timer = 0;

        }
    }

    private void SaveSprite()
    {
        int cubeSize = (int)Math.Sqrt(CubesRoot.childCount);
        int originalSize = (int)FrameSize.x;
        int pixelSize = (int)FrameSize.x/cubeSize;

        Texture2D t = new Texture2D(originalSize, originalSize);




        int x = 0;
        int y = 0;

        for (int i = 0; i < originalSize;)
        {
            

            for (int l = 0; l < originalSize;)
            {
                int cubeIndex = l / pixelSize + (cubeSize*i/pixelSize);
                Transform cube = CubesRoot.GetChild(cubeIndex);
                Color c = cube.GetComponent<MeshRenderer>().material.color;

                y = i;
                for (int j = 0; j < pixelSize; j++)
                {
                    x = l;
                    for (int k = 0; k < pixelSize; k++)
                    {


                        t.SetPixel(x, y, c);
                        t.Apply();
                        x++;

                    }
                    
                    y++;

                }

                l += pixelSize;
            }
            i += pixelSize;
        }

        Sprite s = Sprite.Create(t, new Rect(Vector2.zero, FrameSize), new Vector2(0.5f, 0.5f));
        sprites.Add(s);
        SpriteRenderer.sprite = s;
    }
}
