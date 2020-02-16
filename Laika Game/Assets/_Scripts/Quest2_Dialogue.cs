﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest2_Dialogue : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject player;
    public bool finalDialogue=false;
    public GameObject NPC;
    public GameObject Text;
    public float TalkDistance;
    private float d;
    public int questIndex;
    public Dialogue questStarted;
    public Dialogue questFinished_NoReward;
    public Dialogue questFinished_Reward;
    public GameObject reward;
    private Quaternion originalRot;
    private int sentencesNum;
    
    
    public void TriggerDialogue() {
        Text.SetActive(false);
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, transform.gameObject);
    }

    public void ContinueDialogue() {
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
    }

    void Start()
    {
        d = Vector3.Distance(player.transform.position, NPC.transform.position);
        Text.SetActive(false);
        originalRot = transform.rotation;
        sentencesNum = dialogue.sentences.Length;
    }

    public void generateReward()
    {
        UpdateDialogue_QuestFinished_AfterReward();
        player.gameObject.GetComponent<QuestHolder>().quests[questIndex].complete = true;
        Instantiate(reward, transform.position + (transform.right * -0.7f) +(transform.up * 0.5f), Quaternion.identity);
    }

    public void UpdateDialogue_QuestFinished_BeforeReward()
    {

        for(int i = 0; i <sentencesNum; i++)
        {
            dialogue.sentences[i] = questFinished_NoReward.sentences[i];

        }
        finalDialogue = true;

    }

    public void UpdateDialogue_QuestFinished_AfterReward()
    {
        for (int i = 0; i < sentencesNum; i++)
        {
            dialogue.sentences[i] = questFinished_Reward.sentences[i];
        }
    }


    public void UpdateDialogue_QuestStarted() {
        print(sentencesNum);
        for (int i = 0; i < sentencesNum; i++)
        {
            dialogue.sentences[i] = questStarted.sentences[i];

        }


    }
    // Update is called once per frame
    void Update()
    {
        


        d = Vector3.Distance(player.transform.position, NPC.transform.position);
        if (d < TalkDistance) {
            if (!FindObjectOfType<DialogueManager>().IsTalking()) {
                Text.SetActive(true);
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
            Text.SetActive(false);
            transform.rotation = Quaternion.Slerp(transform.rotation, originalRot, 0.1f);

        }
    }
}