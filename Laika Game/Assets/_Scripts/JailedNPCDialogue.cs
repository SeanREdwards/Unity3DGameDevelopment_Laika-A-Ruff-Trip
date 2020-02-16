using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JailedNPCDialogue : MonoBehaviour
{
    public Dialogue dialogue;
    public Dialogue updatedDialogue;
    public GameObject player;
    public GameObject NPC;
    public float TalkDistance;
    private Quaternion originalRot;
    private float d;
    private List<Quest> q;
    private int sentencesNum;
    public string questTitle_ToUpdate;
    
    public void TriggerDialogue() {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, transform.gameObject);
    }

    public void ContinueDialogue() {
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
    }

    void updateDialogue()
    {
        for(int i = 0; i<sentencesNum; i++)
        {
            dialogue.sentences[i] = updatedDialogue.sentences[i];
        }

    }

    void Start()
    {
        d = Vector3.Distance(player.transform.position, NPC.transform.position);
        originalRot = transform.rotation;
        sentencesNum = dialogue.sentences.Length;
    }

    // Update is called once per frame
    void Update()
    {
        q = player.GetComponent<QuestHolder>().quests;
        if (questTitle_ToUpdate != null)
        {
            for (int i = 0; i < q.Count; i++)
            {
                if (q[i].title == questTitle_ToUpdate && q[i].complete)
                {
                    updateDialogue();
                }
            }
        }


        d = Vector3.Distance(player.transform.position, NPC.transform.position);
        if (d < TalkDistance) {
            if (!FindObjectOfType<DialogueManager>().IsTalking()) {
                if (Input.GetButtonDown("Interact")) {
                    
                    TriggerDialogue();
                    player.gameObject.GetComponent<PlayerMovementController>().enabled = false;
                    player.transform.GetChild(1).GetComponent<Animator>().SetFloat("Speed", 0f);
                    //player.transform.GetChild(1).GetComponent<DogAnimationController>().enabled = false;
                    
                }
            } else {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.transform.position - transform.position), 0.09f);

                if (Input.GetButtonDown("Select")) {
                    ContinueDialogue();
                }
            }
            
        } else {
            transform.rotation = Quaternion.Slerp(transform.rotation, originalRot, 0.1f);

        }
    }
}
