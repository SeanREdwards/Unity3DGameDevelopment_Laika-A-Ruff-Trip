using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBackAndForth : MonoBehaviour
{
    float min, max;
    // Start is called before the first frame update
    void Start()
    {
        min = transform.position.x;
        max = transform.position.x + 25f;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.PingPong(Time.time *5f, max - min) + min,transform.position.y , transform.position.z);

    }
}
