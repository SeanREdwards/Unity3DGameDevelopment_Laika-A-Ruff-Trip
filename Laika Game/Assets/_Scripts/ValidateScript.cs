﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValidateScript : MonoBehaviour
{

    public Text helpText;
    public GameObject Light1;
    public GameObject Light2;
    public GameObject Light3;
    public GameObject Light4;
    public GameObject Light5;
    public PuzzleDoor Door;
    Animator DoorAnimator;

    private void Awake() {
        DoorAnimator = Door.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "Laika") {
            helpText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.name == "Laika") {
            helpText.gameObject.SetActive(false);
        }
    }


    private void OnTriggerStay(Collider other) {
        if (other.gameObject.name == "Laika") {
            if (Input.GetKeyDown("f")) {
                if (Light1.activeSelf && Light2.activeSelf && Light3.activeSelf && Light4.activeSelf && Light5.activeSelf) {
                    Door.Open();
                }
            }
        }
    }
}
