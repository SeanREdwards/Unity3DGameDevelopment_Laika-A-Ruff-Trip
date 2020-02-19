using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallSpawn : MonoBehaviour
{
    public GameObject ball;
    public Text helpText;

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

        }
    }


    private void OnTriggerStay(Collider other) {
        if (other.gameObject.name == "Laika") {
            if (Input.GetKeyDown("f")) {
                rb.velocity = new Vector3(0f, 0f, 0f);
                rb.transform.position = new Vector3(4.7f, 8.2f, 3.5f);
            }
        }
    }
}
