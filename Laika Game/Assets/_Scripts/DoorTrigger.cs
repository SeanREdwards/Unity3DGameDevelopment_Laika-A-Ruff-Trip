using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

//Must set the object being animated (door, bridge) and the appropriate virtual camera
//Must set up virtual camera prior to this
public class DoorTrigger : MonoBehaviour
{
    private bool doorOpen;
    public GameObject door;
    public GameObject playerCam, doorCam;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Pickup" && !doorOpen) //If a pickup is dropped on button
        {
            StartCoroutine(ButtonThenDoor()); 
            doorOpen = true;
        }
    }

    IEnumerator ButtonThenDoor()
    {
        //Animate button press
        transform.gameObject.GetComponent<Animator>().SetTrigger("Big Button Down");
        //Lock player camera input
        playerCam.GetComponent<CinemachineFreeLook>().m_YAxis.m_InputAxisName = "";
        playerCam.GetComponent<CinemachineFreeLook>().m_XAxis.m_InputAxisName = "";

        yield return new WaitForSeconds(1.35f);

        //Transition to appropriate virtual camera
        playerCam.SetActive(false);
        doorCam.SetActive(true);
        Animator doorAnimator = door.GetComponent<Animator>();
        yield return new WaitForSeconds(1.5f);

        //Animate the puzzle piece
        doorAnimator.SetTrigger("DoorOpen");
        yield return new WaitForSeconds(1.5f);

        //Transition back to player camera
        doorCam.SetActive(false);
        playerCam.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        //Reenable player camera lock movement
        playerCam.GetComponent<CinemachineFreeLook>().m_YAxis.m_InputAxisName = "Mouse Y";
        playerCam.GetComponent<CinemachineFreeLook>().m_XAxis.m_InputAxisName = "Mouse X";

        yield break;
    }

}
