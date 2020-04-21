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
    public GameObject pause;
    private Queue<string> sentences = new Queue<string>();
    private IntroCutsceneDialogue intro;
    private JailedNPCDialogue jailed;
    private Quest_Dialogue_Logic q2d;
    private GiveQuest gq;
    private MechanicDialogueUpdater mechD;

    [HideInInspector]
    public bool talking;

    void Start()
    {
        sentences = new Queue<string>();
        talking = false;
        player = transform.parent.gameObject;
    }

    public void StartDialogue(Dialogue dialogue, GameObject talkingNPC) {
        pause.SetActive(false);
        gq = talkingNPC.GetComponent<GiveQuest>();
        intro = talkingNPC.GetComponent<IntroCutsceneDialogue>();
        q2d = talkingNPC.GetComponent<Quest_Dialogue_Logic>();
        mechD = talkingNPC.GetComponent<MechanicDialogueUpdater>();
        jailed = talkingNPC.GetComponent<JailedNPCDialogue>();

        talking = true;
        animator.gameObject.GetComponent<Animator>().SetBool("IsOpen", true);
        nameText.text = dialogue.name;
        if (sentences != null)
        {
            sentences.Clear();
        }

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
        GetComponent<AudioSource>().Play();
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
        GetComponent<AudioSource>().Stop();

    }

    void IntroSceneCameraSwitch()
    {
        intro.CameraSwitch();
    }


    public void EndDialogue() {
        GetComponent<AudioSource>().Stop();
        pause.SetActive(true);
        talking = false;
        animator.gameObject.GetComponent<Animator>().SetBool("IsOpen", false);
        player.gameObject.GetComponent<PlayerMovementController>().enabled = true;


        if (intro != null)
        {
            Invoke("IntroSceneCameraSwitch", 1.3f);
        }

        if(jailed != null)
        {
            jailed.dialogueEnded = true;
        }

        if(q2d != null)
        {
            q2d.dialogueEnded = true;

            if (q2d.dialogueUpdatedBeforeReward)
            {
                q2d.finalDialogue = true;
            }
        }

        if(mechD != null)
        {
            mechD.dialogueEnded = true;
        }

        if (gq != null)
        {
            gq.dialogueEnded = true;           
        }
    }

    public bool IsTalking() {
        return talking;
    }

}
