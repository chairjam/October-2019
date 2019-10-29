using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTarget : MonoBehaviour
{
    public int index;
    public Color color;
    public TargetShapeController targetShapeController;
    public GameObject gameObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision){
        Material mat = gameObject.GetComponent<Renderer>().material;
        print("hit!");
        print(index);
        if (index == targetShapeController.targetIndex)
        {
            mat.color = Color.green;
        }
        else {
            mat.color = Color.blue;
        }
    }
}
