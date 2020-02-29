using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaikaChildOfPlatform : MonoBehaviour
{
    GameObject Laika;
    // Start is called before the first frame update
    void Start()
    {
        Laika = GameObject.Find("Player/Laika");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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

}
