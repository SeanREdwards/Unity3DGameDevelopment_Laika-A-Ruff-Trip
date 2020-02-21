using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValidateScript : MonoBehaviour
{
    public GameObject correctSound;
    public Text helpText;
    public GameObject Light1;
    public GameObject Light2;
    public GameObject Light3;
    public GameObject Light4;
    public GameObject Light5;

    public GameObject Light1R;
    public GameObject Light2R;
    public GameObject Light3R;
    public GameObject Light4R;
    public GameObject Light5R;

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
                    correctSound.SetActive(true);
                } else {
                    this.GetComponent<AudioSource>().Play();

                    MakeRed(Light1, Light1R);
                    MakeRed(Light2, Light2R);
                    MakeRed(Light3, Light3R);
                    MakeRed(Light4, Light4R);
                    MakeRed(Light5, Light5R);
                }
            }
        }
    }

    private void MakeRed(GameObject LightGreen, GameObject LightRed) {
        if(LightGreen.activeSelf) {
            LightRed.SetActive(true);
            LightGreen.SetActive(false);
        }
    }
}
