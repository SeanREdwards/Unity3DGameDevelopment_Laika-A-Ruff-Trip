using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressButton : MonoBehaviour
{

    public GameObject door;
    public Text helpText;
    private bool doorOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Laika" && !doorOpen)
        {
            helpText.gameObject.SetActive(true);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Laika")
        {
            helpText.gameObject.SetActive(false);

        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Laika")
        {
            if (Input.GetKeyDown("f"))
            {
                Animator doorAnimator = door.GetComponent<Animator>();
                doorAnimator.SetTrigger("DoorOpen");
                doorOpen = true;
            }
        }
    }
}
