using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject animator;
    GameObject player;
    private GameObject talker;
    public Text nameText;
    public GameObject hold;
    public Text dialogueText;
    private Queue<string> sentences;
    private IntroCutsceneDialogue intro;

    private Quest2_Dialogue current;
    private GiveQuest gq;

    [HideInInspector]
    public bool talking;

    void Start()
    {
        sentences = new Queue<string>();
        talking = false;
        player = transform.parent.gameObject;
    }

    public void StartDialogue(Dialogue dialogue, GameObject talkingNPC) {

        gq = talkingNPC.GetComponent<GiveQuest>();
        intro = talkingNPC.GetComponent<IntroCutsceneDialogue>();

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

    void IntroSceneCameraSwitch()
    {
        intro.CameraSwitch();
    }


    void EndDialogue() {
        talking = false;
        animator.gameObject.GetComponent<Animator>().SetBool("IsOpen", false);

        if (intro != null)
        {
            Invoke("IntroSceneCameraSwitch", 1.3f);
        }


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
