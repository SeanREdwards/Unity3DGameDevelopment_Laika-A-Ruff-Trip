using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDoor : MonoBehaviour
{
    public Text helpText;
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
                Door.Open();
            }
        }
    }

}
