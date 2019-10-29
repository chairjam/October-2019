using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneInput : MonoBehaviour
{
    [SerializeField]
    private Transform cursor;

    float speed = 10.0f;

    private Vector3 a;

    private Vector3 v = Vector3.zero;

    private Vector3 offset;

    private void Start()
    {
        offset = Input.acceleration;
        Paint.instance.cursors.Add(cursor);
    }

    private void FixedUpdate()
    {
        a = Input.acceleration - offset;

        if (Mathf.Abs(a.y) > 0.01)
            v.z += a.y;
        else
            v.z = 0;
        if (Mathf.Abs(a.x) > 0.01)
            v.x += a.x;
        else
            v.x = 0;

        // Move object
        cursor.Translate(v * Time.fixedDeltaTime);
    }
}
