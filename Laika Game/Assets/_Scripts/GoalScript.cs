using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{

    public PuzzleDoor Door;
    public GameObject correctSound;
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Ball") {
            Door.Open();
            correctSound.SetActive(true);
        }
    }
}
