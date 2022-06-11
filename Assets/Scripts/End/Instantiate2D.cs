using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Instantiate2D : MonoBehaviour
{
    public Transform parent;
    public int nx, nz;
    public float offsetX, offsetZ;
    public GameObject prefab;
    public bool Instantiate;

    Vector3 startT, currT;

    void Update()
    {
        if (Instantiate)
        {


            startT = Vector3.zero;
            currT = Vector3.zero;
            for (int i = 0; i < nx; i++)
            {
                for (int j = 0; j < nz; j++)
                {
                    GameObject go;
                    if (parent != null)
                        go = Instantiate(prefab, parent);
                    else
                        go = Instantiate(prefab);
                    go.transform.localPosition = currT;
                    currT = new Vector3(currT.x + offsetX, currT.y, currT.z);
                    go.transform.SetAsFirstSibling();
                }
                currT = new Vector3(startT.x, currT.y, currT.z + offsetZ);
            }

            Instantiate = false;
        }
    }
}
