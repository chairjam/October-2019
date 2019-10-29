using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Kinect = Windows.Kinect;


public class PoseController : MonoBehaviour
{

    public GameObject[] spheres = new GameObject[100];
    public Vector3 modScale = new Vector3(3.0f, 3.0f, 1.0f);
    public float floatScale = 1;
    public Kinect.JointType joint;

    // Start is called before the first frame update
    void Start()
    {
        //spheres = new GameObject[100];
        //this.transform.position *= floatScale;
        //floatScale = IntParseFast(GameObject.Find("SliderText"));
    }

    // Update is called once per frame
    void Update()
    {
        //floatScale = IntParseFast(GameObject.Find("SliderText"));
        //floatScale = GameObject.Find("Scale Slider").GetComponent<Slider>().value;
        int anchor = GameObject.Find("Brush Anchor").GetComponent<Dropdown>().value;
        //Debug.Log("anchor=" + anchor);
        switch(anchor)
        {
            case 0:
                joint = Kinect.JointType.ThumbRight;
                break;
            case 1:
                joint = Kinect.JointType.ThumbLeft;
                break;
            case 2:
                joint = Kinect.JointType.Head;
                break;
        }
    }
}
