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
        if (other.gameObject.tag == "Pickup")
        {
            StartCoroutine(ButtonThenDoor());
        }
    }

    IEnumerator ButtonThenDoor()
    {

        doorOpen = true;
        transform.gameObject.GetComponent<Animator>().SetTrigger("Big Button Down");
        yield return new WaitForSeconds(2f);
        playerCam.SetActive(false);
        doorCam.SetActive(true);

        Animator doorAnimator = door.GetComponent<Animator>();
        
        yield return new WaitForSeconds(2f);
        doorAnimator.SetTrigger("DoorOpen");
        yield return new WaitForSeconds(1f);
        doorCam.SetActive(false);
        playerCam.SetActive(true);
        yield break;
    }

}
