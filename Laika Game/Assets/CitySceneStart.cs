using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitySceneStart : MonoBehaviour
{
    public GameObject mechanicDialogue;
    public void TriggerDialogue()
    {
        GameObject.Find("Player").gameObject.GetComponent<PlayerMovementController>().enabled = false;
        FindObjectOfType<DialogueManager>().StartDialogue(mechanicDialogue.GetComponent<JailedNPCDialogue>().dialogue, transform.gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {

        Invoke("TriggerDialogue", 0.2f);

        //TriggerDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
