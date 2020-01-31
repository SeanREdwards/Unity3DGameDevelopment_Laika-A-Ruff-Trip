using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour
{

    public float amplitude;
    public float speed;                  
    private float tempVal;
    private Vector3 tempPos;

    // Start is called before the first frame update
    void Start()
    {
        tempVal = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        tempPos.y = tempVal + amplitude * Mathf.Sin(speed * Time.time);
        transform.position = new Vector3(transform.position.x, tempPos.y, transform.position.z);
    }
}
