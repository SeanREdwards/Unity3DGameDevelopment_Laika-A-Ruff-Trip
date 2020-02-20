using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest2_Dialogue : MonoBehaviour
{
    public Dialogue dialogue;
    GameObject player;
    public bool finalDialogue=false;
    public GameObject NPC;
    private float TalkDistance;
    private float d;
    public int questIndex;
    public Dialogue questStarted;
    public Dialogue questFinished_NoReward;
    public Dialogue questFinished_Reward;
    public GameObject reward;
    private Quaternion originalRot;
    private int sentencesNum;

    public GameObject questCompleteWindow;
    public Text questCompleteTitleText;
    public Text questCompleteDescriptionText;
    
    
    public void TriggerDialogue() {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, transform.gameObject);
    }

    public void ContinueDialogue() {
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
    }

    void Start()
    {
        player = GameObject.Find("Player");
        TalkDistance = 2;
        d = Vector3.Distance(player.transform.position, NPC.transform.position);
        originalRot = transform.rotation;
        sentencesNum = dialogue.sentences.Length;
    }

    public void generateReward()
    {
        UpdateDialogue_QuestFinished_AfterReward();
        questCompleteWindow.SetActive(true);
        questCompleteTitleText.text = this.GetComponent<GiveQuest>().quest.completedTitle;
        questCompleteDescriptionText.text = this.GetComponent<GiveQuest>().quest.completedDescription;
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
