using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDoor_BridgeUp : MonoBehaviour
{
    Text helpText;
    public GameObject bridge1, bridge2;
    public GameObject door1, door2;
    public GameObject doorCam;
    Animator DoorAnimator;
    GameObject player;
    bool canPressButton = false;
    public bool oneCameraSwitch = false;

    private void Update()
    {
        if (canPressButton)
        {
            if (Input.GetKeyDown("f"))
            {
                GetComponent<AudioSource>().Play();
                bridge1.GetComponent<Animator>().SetTrigger("BridgeUp");
                bridge2.GetComponent<Animator>().SetTrigger("BridgeUp");
                door1.GetComponent<Animator>().SetTrigger("Door");
                door2.GetComponent<Animator>().SetTrigger("Door");
                Invoke("OneCameraSwitch", 2f);
            }
        }
    }

    void OneCameraSwitch()
    {
        doorCam.SetActive(false);
        oneCameraSwitch = true;
    }

    private void Awake() {
        player = GameObject.Find("Player");
        helpText = player.transform.GetChild(5).GetChild(0).gameObject.GetComponent<Text>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "Laika") {
            helpText.gameObject.SetActive(true);
            canPressButton = true;
            if(doorCam != null && !oneCameraSwitch)
            {
                print("here");
                print(oneCameraSwitch);
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
