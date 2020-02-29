using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongXMovement : MonoBehaviour
{


    public float min, max, speed;
    float xPos;
    bool decreasing, increasing;
    // Start is called before the first frame update
    void Start()
    {
        increasing = true;
        decreasing = false;
        xPos = transform.position.x;

    }

    // Update is called once per frame
    void Update()
    {
        if (xPos > max)
        {
            xPos = max;
            increasing = false;
            decreasing = true;
        }
        else if (xPos < min)
        {
            xPos = min;
            increasing = true;
            decreasing = false;
        }

        if (xPos < max && increasing)
        {
            xPos += Time.deltaTime * speed;
        }
        else if (xPos > min && decreasing)
        {
            xPos -= Time.deltaTime * speed;
        }
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);

    }
}
