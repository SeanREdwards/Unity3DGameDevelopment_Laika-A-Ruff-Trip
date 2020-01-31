using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackForthWRotate : MonoBehaviour
{

    public float speed = 1f;
    float oldXVal = 0f;
    float newXVal = 0f;
    public GameObject pillar;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {            

        oldXVal = transform.position.x;
        newXVal = Mathf.PingPong(Time.time * speed, 5);
        transform.position = new Vector3(newXVal, transform.position.y, transform.position.z);
        
    }
}
