using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public class JailedNPCDialogue : MonoBehaviour
{
    public Dialogue dialogue;
    public Dialogue updatedDialogue;
    GameObject player;
    //public GameObject NPC;
    private float TalkDistance;
    private Quaternion originalRot;
    private float d;
    private List<Quest> q;
    private int sentencesNum;
    public GameObject talktip;
    public string questTitle_ToUpdate;
    public bool isMechanic;
    [HideInInspector]
    public bool dialogueEnded;
    public bool bossFight;
    bool canTalk = false;
    bool activated = false;
    public GameObject bossOverviewCam;
    
    public void TriggerDialogue() {
        player.GetComponent<AudioSource>().Stop();
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, transform.gameObject);
    }

    public void ContinueDialogue() {
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
    }

    public void updateDialogue()
    {
        for(int i = 0; i<sentencesNum; i++)
        {
            dialogue.sentences[i] = updatedDialogue.sentences[i];
        }

    }

    void Start()
    {
        originalRot = transform.rotation;
        sentencesNum = dialogue.sentences.Length;
        player = GameObject.Find("Player");
        talktip = player.transform.GetChild(5).GetChild(2).gameObject;
        q = player.GetComponent<QuestHolder>().quests;
        d = Vector3.Distance(player.transform.position, transform.position);
        TalkDistance = 3;

    }

    void ActivateTalkTip()
    {
        talktip.SetActive(true);
    }

    void DeactivateTalkTip()
    {
        talktip.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {


        if (canTalk && !activated)
        {
            activated = true;
            ActivateTalkTip();

        }
        else if (!canTalk && activated)
        {
            activated = false;
            DeactivateTalkTip();
        }

        if (bossFight && dialogueEnded)
        {
            player.transform.GetChild(6).gameObject.SetActive(true);
            bossOverviewCam.SetActive(false);
            talktip.SetActive(true);
            dialogueEnded = false;
        }

        if (dialogueEnded)
        {
            talktip.SetActive(true);
            dialogueEnded = false;
        }

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
        d = Vector3.Distance(player.transform.position, transform.position);
        if (d < TalkDistance) {
            canTalk = true;

            if (!FindObjectOfType<DialogueManager>().IsTalking()) {
                if (Input.GetButtonDown("Interact")) {
                    talktip.SetActive(false);

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
            canTalk = false;

            //talktip.SetActive(false);
            transform.rotation = Quaternion.Slerp(transform.rotation, originalRot, 0.1f);

        }
    }
}




