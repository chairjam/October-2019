using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetShapeController : MonoBehaviour
{
    public GameObject prefab;
    public GameObject targetPrefab;
    public int targetIndex;
    private int[] targetIndices;

    // Start is called before the first frame update
    void Start()
    {
        //CreateClock();
        targetIndex = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateClock() {
        int radius = 10;
        float thetaStep = Mathf.Deg2Rad * 360.0f / 12;
        float scale = 15;
        for (int x = 0; x < 12; x++)
        {
            float theta = x * thetaStep;
            Vector3 origin = GameObject.Find("ClockSprite").transform.position;
            Vector3 pos = new Vector3(origin.x  + Mathf.Sin(theta) * scale, 0.0f, origin.y + Mathf.Cos(theta) * scale);
            GameObject obj = Instantiate(targetPrefab, pos, Quaternion.identity);
            print("made");
        }
    }
}
