using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongYMovement : MonoBehaviour
{
    public float min, max, speed;
    float yPos;
    bool decreasing, increasing;
    // Start is called before the first frame update
    void Start()
    {
        increasing = true;
        decreasing = false;
        yPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {

        if(yPos > max)
        {
            yPos = max;
            increasing = false;
            decreasing = true;
        } else if (yPos < min)
        {
            yPos = min;
            increasing = true;
            decreasing = false;
        }

        if(yPos < max && increasing)
        {
            yPos += Time.deltaTime * speed;
        } else if (yPos > min && decreasing)
        {
            yPos -= Time.deltaTime * speed;
        }
        transform.position = new Vector3(transform.position.x, yPos, transform.position.z);

    }

}
