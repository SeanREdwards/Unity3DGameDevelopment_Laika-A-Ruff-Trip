using System.Collections;
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
                LightSelfRed.SetActive(!LightSelfRed.activeSelf);
                LightSelfGreen.SetActive(!LightSelfGreen.activeSelf);

                LightLeftRed.SetActive(!LightLeftRed.activeSelf);
                LightLeftGreen.SetActive(!LightLeftGreen.activeSelf);

                LightRightRed.SetActive(!LightRightRed.activeSelf);
                LightRightGreen.SetActive(!LightRightGreen.activeSelf);
            }
        }
    }

}
