using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HasDialogue : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject player;
    public bool finalDialogue=false;
    public bool isQuestGiver;
    public bool questGiven;
    public GameObject NPC;
    public GameObject Text;
    public float TalkDistance;
    private float d;
    public int questIndex;
    public GameObject reward;
    
    
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
        questGiven = false;
    }

    public void generateReward()
    {
        UpdateDialogue_QuestFinished_AfterReward();
        Instantiate(reward, new Vector3(transform.position.x+1f, transform.position.y+0.5f, transform.position.z), Quaternion.identity);
    }

    public void UpdateDialogue_QuestFinished_BeforeReward()
    {
        dialogue.sentences[0] = "Oh, my bottle!";
        dialogue.sentences[1] = "Thank you so much, Laika!";
        dialogue.sentences[2] = "Here is some ham for you!";
        finalDialogue = true;
        StaticVariableHolder.Quest1_Done = true;

    }

    public void UpdateDialogue_QuestFinished_AfterReward()
    {
        dialogue.sentences[0] = "Thanks again for getting my bottle!";
        dialogue.sentences[1] = "I owe you, Laika.";
        dialogue.sentences[2] = "Sadly, I have no more bones, but dinner is on me next time!";
    }


    public void UpdateDialogue_QuestStarted() { 


        dialogue.sentences[0] = "Oh, Laika. Did you happen to find my bottle?";
        dialogue.sentences[1] = "Did you forget where to look?";
        dialogue.sentences[2] = "I dropped my bottle in front of the strip club...";
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
                if (Input.GetButtonDown("Select")) {
                    ContinueDialogue();
                }
            }
            
        } else {
            Text.SetActive(false);
        }
    }
}
