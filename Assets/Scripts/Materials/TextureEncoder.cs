using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TextureEncoder : MonoBehaviour
{
    public Texture2D TextureToEncode;
    public bool EncodeTexture = false;
    public string FileName;

    void Update()
    {
        if (EncodeTexture)
        {
            EncodeTexture = false;
            // Encode texture into PNG
            byte[] bytes = TextureToEncode.EncodeToJPG();
            //Application.dataPath  - Unity Editor: <path to project folder>/Assets
            //                      - Win player: < path to executablename_Data folder >
            File.WriteAllBytes(Application.dataPath + "/../" + FileName + ".png", bytes);
        }
    }
}
