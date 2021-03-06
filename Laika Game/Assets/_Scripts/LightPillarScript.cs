﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightPillarScript : MonoBehaviour
{
    public Text helpText;
    public GameObject LightSelfRed;
    public GameObject LightSelfGreen;
    public GameObject LightLeftRed;
    public GameObject LightLeftGreen;
    public GameObject LightRightRed;
    public GameObject LightRightGreen;
    private bool inTrigger, callOnce;
    bool canPress = false;

    private void Start()
    {
        inTrigger = false;
    }

    private void Update()
    {
        if (canPress)
        {
            if (Input.GetKeyDown("f"))
            {

                this.GetComponent<AudioSource>().Play();

                LightSelfRed.SetActive(!LightSelfRed.activeSelf);
                LightSelfGreen.SetActive(!LightSelfGreen.activeSelf);

                LightLeftRed.SetActive(!LightLeftRed.activeSelf);
                LightLeftGreen.SetActive(!LightLeftGreen.activeSelf);

                LightRightRed.SetActive(!LightRightRed.activeSelf);
                LightRightGreen.SetActive(!LightRightGreen.activeSelf);
            }
        }

        /*
        if (inTrigger && callOnce)
        {
                this.GetComponent<AudioSource>().Play();
            
            //print(other.gameObject.name);
            LightSelfRed.SetActive(!LightSelfRed.activeSelf);
            LightSelfGreen.SetActive(!LightSelfGreen.activeSelf);

            LightLeftRed.SetActive(!LightLeftRed.activeSelf);
            LightLeftGreen.SetActive(!LightLeftGreen.activeSelf);

            LightRightRed.SetActive(!LightRightRed.activeSelf);
            LightRightGreen.SetActive(!LightRightGreen.activeSelf);
            callOnce = false;
        }
        */
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "Laika") {
            helpText.gameObject.SetActive(true);
            canPress = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.name == "Laika") {
            helpText.gameObject.SetActive(false);
            canPress = false;
        }
    }

    /*
    private void OnTriggerStay(Collider other) {
        if (other.gameObject.name == "Laika") {

            if (Input.GetKeyDown("f")) {
                
                inTrigger = true;
                callOnce = true;
            }
        }
    }
    */
}
