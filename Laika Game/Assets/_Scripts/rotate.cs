using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    public float rotationsPerMinute;
    // Start is called before the first frame update
    void Start()
    {
        rotationsPerMinute = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(0, 6.0f * rotationsPerMinute * Time.deltaTime, 0);
    }

    private void FixedUpdate()
    {
        transform.Rotate(0, 6.0f * rotationsPerMinute * Time.deltaTime, 0);
    }
}
