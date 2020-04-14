using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallButtonMove : MonoBehaviour
{
    public Text helpText;
    public Block Block;
    Animator BlockAnimator;

    private void Awake() {
        BlockAnimator = Block.GetComponent<Animator>();
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
                if (Block.IsMoved()) {
                    Block.Move();
                } else {
                    Block.Return();
                }
            }
        }
    }
}
