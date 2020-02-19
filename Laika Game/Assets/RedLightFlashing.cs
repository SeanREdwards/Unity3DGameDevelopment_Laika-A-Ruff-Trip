using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedLightFlashing : MonoBehaviour
{

    Color redColor = Color.red;
    Color blackColor = Color.black;
    Light lt;
    // Start is called before the first frame update
    void Start()
    {
        lt = transform.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        float f = Mathf.PingPong(Time.time, .9f);
        lt.color = Color.Lerp(redColor, blackColor, f);
    }
}
