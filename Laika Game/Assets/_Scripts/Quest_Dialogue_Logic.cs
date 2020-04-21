using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest_Dialogue_Logic : MonoBehaviour
{
    public Dialogue dialogue;
    GameObject player;
    [HideInInspector]
    public bool finalDialogue=false;
    [HideInInspector]
    public GameObject NPC;
    private float TalkDistance;
    private float d;
    [HideInInspector]
    public int questIndex;
    public Dialogue questStarted;
    public Dialogue questFinished_NoReward;
    public GameObject talktip;
    bool canTalk = false;
    bool activated = false;
    public Dialogue questFinished_Reward;
    public GameObject reward;
    private Quaternion originalRot;
    private int sentencesNum;
    [HideInInspector]
    public bool dialogueEnded = false;
    [HideInInspector]
    public bool dialogueUpdatedBeforeReward = false;
    private GiveQuest gq;
    
    
    public void TriggerDialogue() {
        player.GetComponent<AudioSource>().Stop();

        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, transform.gameObject);
    }

    public void ContinueDialogue() {
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
    }

    void Start()
    {
        NPC = this.gameObject;
        gq = GetComponent<GiveQuest>();
        player = GameObject.Find("Player");
        talktip = player.transform.GetChild(5).GetChild(2).gameObject;

        TalkDistance = 2;
        d = Vector3.Distance(player.transform.position, NPC.transform.position);
        originalRot = transform.rotation;
        sentencesNum = dialogue.sentences.Length;

        List<Quest> qs = player.GetComponent<QuestHolder>().quests;
        string title = gq.quest.title;
        for(int i = 0; i < qs.Count; i++)
        {
            if(title.Equals(qs[i].title))
            {
                UpdateQuest(qs[i], i);
            }
        }
    }

    void UpdateQuest(Quest q, int i)
    {
        gq.questGiven = true;
        print(i);
        print(q.title);
        gq.quest.collectibleItem.GetComponent<QuestItem>().questIndex = i;
        if (!q.gotItem)
        {
            gq.SpawnItem(1);
            UpdateDialogue_QuestStarted();
        } else if(q.gotItem && !q.complete)
        {
            UpdateDialogue_QuestFinished_BeforeReward();
            questIndex = i;
        } else if(q.gotItem && q.complete)
        {
            UpdateDialogue_QuestFinished_AfterReward();
        }
    }

    public void generateReward()
    {
        UpdateDialogue_QuestFinished_AfterReward();
        gq.UpdateWindow();
        //questCompleteWindow.SetActive(true);
        //questCompleteTitleText.text = this.GetComponent<GiveQuest>().quest.completedTitle;
        //questCompleteDescriptionText.text = this.GetComponent<GiveQuest>().quest.completedDescription;
        this.GetComponent<AudioSource>().Play();
        player.gameObject.GetComponent<QuestHolder>().quests[questIndex].complete = true;
        Instantiate(reward, transform.position + (transform.right * -0.7f) +(transform.up * 0.5f), Quaternion.identity);
    }

    public void UpdateDialogue_QuestFinished_BeforeReward()
    {
        for(int i = 0; i <sentencesNum; i++)
        {
            dialogue.sentences[i] = questFinished_NoReward.sentences[i];
        }
        dialogueUpdatedBeforeReward = true;
    }

    public void UpdateDialogue_QuestFinished_AfterReward()
    {
        for (int i = 0; i < sentencesNum; i++)
        {
            dialogue.sentences[i] = questFinished_Reward.sentences[i];
        }
    }


    public void UpdateDialogue_QuestStarted() {
        for (int i = 0; i < sentencesNum; i++)
        {
            dialogue.sentences[i] = questStarted.sentences[i];

        }


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


        if (finalDialogue && dialogueEnded)
        {
            generateReward();
            finalDialogue = false;
            dialogueEnded = false;
            dialogueUpdatedBeforeReward = false;
        }

        if (dialogueEnded)
        {
            talktip.SetActive(true);
            dialogueEnded = false;
        }

        d = Vector3.Distance(player.transform.position, NPC.transform.position);
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
            // talktip.SetActive(false);
            canTalk = false;
            transform.rotation = Quaternion.Slerp(transform.rotation, originalRot, 0.1f);

        }
    }
}
