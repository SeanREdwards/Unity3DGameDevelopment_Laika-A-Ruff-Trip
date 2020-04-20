﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildBattery : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name == "Battery")
        {
            other.gameObject.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name == "Battery")
        {
            other.gameObject.transform.parent = null;
        }
    }
}
