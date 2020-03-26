using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTriggerSwitch : MonoBehaviour
{

    public GameObject previousCam;
    public GameObject nextCam;
    public bool SwitchingFromFreeCam, SwitchingToFreeCam;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Laika")
        {
            if (SwitchingFromFreeCam)
            {
                other.transform.parent.GetChild(6).gameObject.SetActive(false);
            }
            else
            {
                previousCam.SetActive(false);
            }

            if (SwitchingToFreeCam)
            {
                other.transform.parent.GetChild(6).gameObject.SetActive(true);
            }
            else
            {
                nextCam.SetActive(true);
            }
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
