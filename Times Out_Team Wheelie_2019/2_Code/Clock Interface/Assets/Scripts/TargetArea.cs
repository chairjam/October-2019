using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetArea : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ignoreCollisions")
            return;
        print(collision.gameObject.tag);
        Material mat = GetComponent<Renderer>().material;
        mat.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        //print("hit!");
    }
}
