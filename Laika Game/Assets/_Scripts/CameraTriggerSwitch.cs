using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTriggerSwitch : MonoBehaviour
{

    public GameObject previousCam;
    public GameObject nextCam;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Laika")
        {
            previousCam.SetActive(false);
            nextCam.SetActive(true);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
