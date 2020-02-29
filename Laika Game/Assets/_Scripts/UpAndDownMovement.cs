using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpAndDownMovement : MonoBehaviour
{
    float min, max;
    // Start is called before the first frame update
    void Start()
    {
        min = transform.position.y;
        max = transform.position.y + 0.15f;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time * .2f, max - min) + min, transform.position.z);

    }
}
