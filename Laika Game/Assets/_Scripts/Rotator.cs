using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float xRotate;
    public float yRotate;
    public float zRotate;
    private float min;
    private float max;
    // Update is called once per frame
    private void Start()
    {
        min = transform.position.y;
        max = transform.position.y + 0.15f;
    }

    void Update()
    {
        transform.Rotate(new Vector3(xRotate, yRotate, zRotate) * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time*.2f, max-min)+min, transform.position.z);
    }
}
