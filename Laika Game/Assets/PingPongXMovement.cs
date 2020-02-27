using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovements : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == Laika)
        {
            Laika.transform.parent.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Laika)
        {
            Laika.transform.parent.parent = null;
        }
    }


    public float min, max;
    float xPos;
    bool decreasing, increasing;
    GameObject Laika;
    // Start is called before the first frame update
    void Start()
    {
        Laika = GameObject.Find("Player/Laika");

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
            xPos += .03f;
        }
        else if (xPos > min && decreasing)
        {
            xPos -= .03f;
        }
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);

    }
}
