using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDoor : MonoBehaviour
{
    public Text helpText;
    public PuzzleDoor Door;
    public GameObject doorCam;
    Animator DoorAnimator;
    GameObject player;
    bool canPressButton = false;

    private void Update()
    {
        if (canPressButton)
        {
            if (Input.GetKeyDown("f"))
            {
                Door.Open();
                GetComponent<AudioSource>().Play();
            }
        }
    }

    private void Awake() {
        DoorAnimator = Door.GetComponent<Animator>();
        player = GameObject.Find("Player");
        helpText = player.transform.GetChild(5).GetChild(0).gameObject.GetComponent<Text>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "Laika") {
            helpText.gameObject.SetActive(true);
            canPressButton = true;
            if(doorCam != null)
            {
                doorCam.SetActive(true);
            }

        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.name == "Laika") {
            helpText.gameObject.SetActive(false);
            canPressButton = false;
            if (doorCam != null)
            {
                doorCam.SetActive(false);
            }

        }

    }

    /*
    private void OnTriggerStay(Collider other) {
        if (other.gameObject.name == "Laika") {
            if (Input.GetKeyDown("f")) { 
                Door.Open();
                GetComponent<AudioSource>().Play();
            }
        }
    }
    */
}
