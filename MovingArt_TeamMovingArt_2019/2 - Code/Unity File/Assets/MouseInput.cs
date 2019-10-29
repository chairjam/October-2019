using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    [SerializeField]
    private Transform cursor;

    [SerializeField]
    private float scale = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Paint.instance.cursors.Add(cursor);
    }

    // Update is called once per frame
    void Update()
    {
        cursor.Rotate(Vector3.up, -Input.GetAxis("Mouse X") * scale * 5);
        cursor.position += -Input.GetAxis("Mouse Y") * scale * cursor.forward;

    }
}
