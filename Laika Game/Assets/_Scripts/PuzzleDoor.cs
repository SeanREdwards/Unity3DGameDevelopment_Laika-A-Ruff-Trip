using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleDoor : MonoBehaviour
{

    public GameObject Door;
    public Animator DoorAnimator;

    void Start()
    {
        DoorAnimator = Door.GetComponent<Animator>();
    }

    public void Open() {
        DoorAnimator.SetTrigger("Open Door");
    }

}
