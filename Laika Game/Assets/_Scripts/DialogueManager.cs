using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject animator;
    public GameObject player;
    private GameObject talker;
    public Text nameText;
    public GameObject hold;
    public Text dialogueText;
    private Queue<string> sentences;
    Object t;

    private Quest2_Dialogue current;
    private GiveQuest gq;


    public bool talking;

    void Start()
    {
        sentences = new Queue<string>();
        talking = false;
    }

    public void StartDialogue(Dialogue dialogue, GameObject talkingNPC) {

        gq = talkingNPC.GetComponent<GiveQuest>();
        talking = true;
        animator.gameObject.GetComponent<Animator>().SetBool("IsOpen", true);
        current = talkingNPC.GetComponent<Quest2_Dialogue>();
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences) {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence() {
        if (sentences.Count == 0) {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence) {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray()) {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void BeginQuest()
    {
        gq.questWindow.SetActive(true);
        gq.questTitleText.text = gq.quest.title;
        
        gq.questDescriptionText.text = gq.quest.description;
        gq.questIndex = gq.quest.questIndex;
        current.UpdateDialogue_QuestStarted();
    }

    void EndDialogue() {
        talking = false;
        animator.gameObject.GetComponent<Animator>().SetBool("IsOpen", false);
        if (gq != null)
        {
            if (gq.isQuestGiver && !gq.questGiven)
            {
                BeginQuest();
                gq.questGiven = true;
            }
            else
            {
                player.gameObject.GetComponent<PlayerMovementController>().enabled = true;
            }

            if (current.finalDialogue)
            {
                current.finalDialogue = false;
                current.generateReward();
            }
        } else
        {
            player.gameObject.GetComponent<PlayerMovementController>().enabled = true;

        }



    }

    public bool IsTalking() {
        return talking;
    }

}
