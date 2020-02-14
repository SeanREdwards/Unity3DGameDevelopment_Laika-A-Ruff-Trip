using System.Collections;
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
    }

    public void generateReward()
    {
        UpdateDialogue_QuestFinished_AfterReward();
        player.gameObject.GetComponent<QuestHolder>().quests[questIndex].complete = true;
        Instantiate(reward, transform.position + (transform.right * -0.7f) +(transform.up * 0.5f), Quaternion.identity);
    }

    public void UpdateDialogue_QuestFinished_BeforeReward()
    {
        dialogue.sentences[0] = questFinished_NoReward.sentences[0];
        dialogue.sentences[1] = questFinished_NoReward.sentences[1];
        dialogue.sentences[2] = questFinished_NoReward.sentences[2];
        finalDialogue = true;
        StaticVariableHolder.Quest2_Done = true;

    }

    public void UpdateDialogue_QuestFinished_AfterReward()
    {
        dialogue.sentences[0] = questFinished_Reward.sentences[0];
        dialogue.sentences[1] = questFinished_Reward.sentences[1];
        dialogue.sentences[2] = questFinished_Reward.sentences[2];
    }


    public void UpdateDialogue_QuestStarted() { 


        dialogue.sentences[0] = questStarted.sentences[0];
        dialogue.sentences[1] = questStarted.sentences[1];
        dialogue.sentences[2] = questStarted.sentences[2];
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
