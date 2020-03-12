using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundLaika : MonoBehaviour
{
    public GameObject Laika;
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //transform.LookAt(Laika.transform);
            transform.RotateAround(Laika.transform.position, Vector3.up, Input.GetAxis("Mouse X") * speed);
        }
    }
}
