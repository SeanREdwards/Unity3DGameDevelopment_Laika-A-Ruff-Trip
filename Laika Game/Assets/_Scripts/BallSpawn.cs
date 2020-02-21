using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallSpawn : MonoBehaviour
{
    public GameObject ball;
    public Text helpText;
    public GameObject ballCam, playerCam;
    private Rigidbody rb;
    void Awake() {
        rb = ball.GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "Laika") {
            helpText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.name == "Laika") {
            helpText.gameObject.SetActive(false);
            ballCam.SetActive(false);
            playerCam.SetActive(true);
            ballCam.GetComponent<CinemachineVirtualCamera>().LookAt = null;


        }
    }


    private void OnTriggerStay(Collider other) {
        if (other.gameObject.name == "Laika") {
            ballCam.SetActive(true);
            playerCam.SetActive(false);
            ballCam.GetComponent<CinemachineVirtualCamera>().LookAt = ball.transform;

            if (Input.GetKeyDown("f")) {
                Invoke("SpawnBall", 0.5f);
                this.GetComponent<AudioSource>().Play();
            }
        }
    }

    void SpawnBall()
    {
        rb.velocity = new Vector3(0f, 0f, 0f);
        rb.transform.position = new Vector3(4.7f, 8.2f, 3.5f);
    }

    void PlayerCamBack()
    {
        ballCam.SetActive(false);
        playerCam.SetActive(true);
    }

}
