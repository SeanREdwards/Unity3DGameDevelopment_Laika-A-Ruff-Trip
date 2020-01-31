using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{

    public GameObject door;
    public bool doorOpen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Animator doorAnimator = door.GetComponent<Animator>();
        doorAnimator.SetTrigger("DoorOpen");
    }
}
