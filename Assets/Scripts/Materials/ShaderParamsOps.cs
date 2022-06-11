using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderParamsOps : MonoBehaviour
{
    public MeshRenderer MRenderer;
    public Texture[] AlbedoTextures;
    public Vector2 UVOffset;
    public Vector2 UVTiling;
    [Range(0, 1)]
    public float Metallic;
    [Range(0,1)]
    public float Smoothness;
    public bool ChangeTexture;
    public Color MainColor;
    int currTextureIndex;
    Material currMat;

    // Start is called before the first frame update
    void Start()
    {
        MainColor = Color.white;
        UVTiling = UVOffset = Vector2.one;

        currMat = MRenderer.material;
        //currMat = MRenderer.sharedMaterial;
    }
    // Update is called once per frame
    void Update()
    {
        if (ChangeTexture)
        {
            ChangeTexture = false;
            currMat.SetTexture("_BaseMap", AlbedoTextures[currTextureIndex]);
            currTextureIndex = (currTextureIndex+1)% AlbedoTextures.Length;
        }
        //Texture UV
        currMat.SetTextureOffset("_BaseMap", UVOffset);
        currMat.SetTextureScale("_BaseMap", UVTiling);

        //Smoothness source must be set on Albedo Alpha
        currMat.SetFloat("_Smoothness", Smoothness);
        currMat.SetFloat("_Metallic", Metallic);
        currMat.SetColor("_BaseColor", MainColor);
    }
    private void OnDestroy()
    {
        //We must destroy the material instance
        if(currMat != MRenderer.sharedMaterial)
            Destroy(currMat);
    }
}
