using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAndForthMovement : MonoBehaviour
{

    public float speed = 1f;
    public GameObject Laika;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == Laika)
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

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.PingPong(Time.time * speed, 5), transform.position.y, transform.position.z);
    }
}
