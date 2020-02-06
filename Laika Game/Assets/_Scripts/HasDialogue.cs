using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasDialogue : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject Player;
    public GameObject NPC;
    public GameObject Text;
    public float TalkDistance;
    private float d;
    
    
    public void TriggerDialogue() {
        Text.SetActive(false);
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public void ContinueDialogue() {
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
    }

    void Start()
    {
        d = Vector3.Distance(Player.transform.position, NPC.transform.position);
        Text.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        d = Vector3.Distance(Player.transform.position, NPC.transform.position);
        if (d < TalkDistance) {
            if (!FindObjectOfType<DialogueManager>().IsTalking()) {
                Text.SetActive(true);
                if (Input.GetButtonDown("Interact")) {
                    
                    TriggerDialogue();
                }
            } else {
                if (Input.GetButtonDown("Select")) {
                    ContinueDialogue();
                }
            }
            
        } else {
            Text.SetActive(false);
        }
    }
}
