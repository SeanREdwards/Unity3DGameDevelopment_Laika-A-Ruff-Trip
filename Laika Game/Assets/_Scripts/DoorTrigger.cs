using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class DoorTrigger : MonoBehaviour
{
    private bool doorOpen;
    public GameObject door;
    public GameObject playerCam, doorCam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Pickup" && !doorOpen)
        {
            StartCoroutine(ButtonThenDoor());
            doorOpen = true;
        }
    }

    IEnumerator ButtonThenDoor()
    {

        doorOpen = true;
        transform.gameObject.GetComponent<Animator>().SetTrigger("Big Button Down");
        playerCam.GetComponent<CinemachineFreeLook>().m_YAxis.m_InputAxisName = "";
        playerCam.GetComponent<CinemachineFreeLook>().m_XAxis.m_InputAxisName = "";

        yield return new WaitForSeconds(1.35f);

        playerCam.SetActive(false);
        doorCam.SetActive(true);
        Animator doorAnimator = door.GetComponent<Animator>();
        yield return new WaitForSeconds(1.5f);
        doorAnimator.SetTrigger("Open");
        yield return new WaitForSeconds(1.5f);
        doorCam.SetActive(false);
        
        playerCam.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        playerCam.GetComponent<CinemachineFreeLook>().m_YAxis.m_InputAxisName = "Mouse Y";
        playerCam.GetComponent<CinemachineFreeLook>().m_XAxis.m_InputAxisName = "Mouse X";

        yield break;
    }

}
