using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Paint : MonoBehaviour
{
    public static Paint instance;

    public MeshRenderer paint;
    
    public List<Transform> cursors;

    public Vector3 cursorInit;
    
    public List<Color> paintColors;
    
    public Texture2D blank;

    public int cur = 0;

    private Texture2D texture;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        texture = Instantiate(blank);
        paint.material.SetTexture("_MainTex", texture);
        for(int u = 0; u < texture.width; u++)
        {
            for(int v = 0; v < texture.height; v++)
            {
                texture.SetPixel(u, v, Color.white);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < cursors.Count; i++)
        {
            if (cursors[i] != null)
            {
                int u = (int)((cursors[i].position.x - cursorInit.x) * 10 + 425);
                int v = (int)(-(cursors[i].position.z - cursorInit.z) * 10 + 400);

                for (int _u = u - 8; _u < u + 8; _u++)
                {
                    for (int _v = v - 8; _v < v + 8; _v++)
                    {
                        if (texture.GetPixel(_u, _v) != Color.white)
                            texture.SetPixel(_u, _v, texture.GetPixel(_u, _v) * 0.5f + paintColors[i] * 0.5f);
                        else
                            texture.SetPixel(_u, _v, paintColors[i]);
                    }
                }
            }
        }

        // Apply all SetPixel calls
        texture.Apply();
    }

    private void OnDestroy()
    {
        File.WriteAllBytes(System.DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".jpg", texture.EncodeToJPG());
    }
}
