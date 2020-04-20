using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightStart : MonoBehaviour
{

    public GameObject alienFighter, overviewCam;
    GameObject laika;
    public void TriggerDialogue()
    {
        laika.GetComponent<PlayerMovementController>().enabled = false;
        laika.transform.GetChild(6).gameObject.SetActive(false);
        overviewCam.SetActive(true);
        FindObjectOfType<DialogueManager>().StartDialogue(alienFighter.GetComponent<JailedNPCDialogue>().dialogue, alienFighter);
    }


    // Start is called before the first frame update
    void Start()
    {
        laika = GameObject.Find("Player");

        Invoke("TriggerDialogue", 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
