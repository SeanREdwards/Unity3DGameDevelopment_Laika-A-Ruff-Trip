using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongZMovement : MonoBehaviour
{
    public float min, max;
    float zPos;
    bool decreasing, increasing;
    // Start is called before the first frame update
    void Start()
    {
        increasing = true;
        decreasing = false;
        zPos = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {

        if(zPos > max)
        {
            zPos = max;
            increasing = false;
            decreasing = true;
        } else if (zPos < min)
        {
            zPos = min;
            increasing = true;
            decreasing = false;
        }

        if(zPos < max && increasing)
        {
            zPos += .07f;
        } else if (zPos > min && decreasing)
        {
            zPos -= .07f;
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, zPos);

    }

}
