using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public class IntroCutsceneDialogue : MonoBehaviour
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
    private bool oneDialogue = false;
    public string questTitle_ToUpdate;
    public GameObject playerCam, doorCam, rocketCrashCam;
    public GameObject rocket;
    public GameObject crashLandingSpot;

    public GameObject alarmSound;
    public GameObject rocketFlyingSound;
    public GameObject explosionSound;
    public GameObject fireBurning;
    public GameObject music;


    public void TriggerDialogue() {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, transform.gameObject);
    }

    public void ContinueDialogue() {
        FindObjectOfType<DialogueManager>().DisplayNextSentence();
    }

    public void CameraSwitch()
    {
        doorCam.SetActive(true);
        alarmSound.SetActive(false);
        Invoke("RocketMoveToWormhole", 0.4f);
    }

    void RocketMoveToWormhole()
    {
        rocket.GetComponent<Animator>().SetTrigger("RocketMove");
        doorCam.SetActive(false);
        Invoke("RocketCrashLand", 2.7f);
    }

    void RocketCrashLand()
    {
        rocketCrashCam.SetActive(true);
        rocketCrashCam.GetComponent<CinemachineVirtualCamera>().LookAt = rocket.transform;
        crashLandingSpot.SetActive(true);
        rocket.GetComponent<Animator>().SetTrigger("RocketCrash");
        //rocket.transform.GetChild(9).gameObject.SetActive(true);
        Invoke("ContactExplosion", 2.1f);
        TalkDistance = 2;
    }

    void ContactExplosion()
    {
        rocket.transform.GetChild(9).gameObject.SetActive(true);
        rocketFlyingSound.SetActive(false);
        explosionSound.SetActive(true);
        fireBurning.SetActive(true);

        Invoke("PlayerControl", 3f);
    }


    void PlayerControl()
    {
        rocketCrashCam.SetActive(false);
        player.transform.position = new Vector3(7.05f, 11.2f, 58.87559f);
        player.transform.GetChild(7).gameObject.SetActive(true);
        Invoke("MechanicTalk", 4f);
        rocket.transform.GetChild(9).gameObject.SetActive(false);
        explosionSound.SetActive(false);

    }
    
    void MechanicTalk()
    {
        rocket.transform.GetChild(9).gameObject.SetActive(true);
        explosionSound.SetActive(true);
        Invoke("RocketSmoking", .9f);

    }

    void RocketSmoking()
    {
        rocket.transform.GetChild(8).gameObject.SetActive(false);
        rocket.transform.GetChild(10).gameObject.SetActive(true);
        music.SetActive(true);
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
        originalRot = transform.rotation;
        sentencesNum = dialogue.sentences.Length;
        player = GameObject.Find("Player");
        q = player.GetComponent<QuestHolder>().quests;
        d = Vector3.Distance(player.transform.position, transform.position);
        TalkDistance = 500;
        Invoke("BeginDialogue", 3f);

    }

    void BeginDialogue()
    {
        TriggerDialogue();
        oneDialogue = true;
        playerCam.SetActive(false);

    }

    void SkipCutscene()
    {
        print("SKIPPING");
        CancelInvoke();
        
        //Enable crash landing spot
        crashLandingSpot.SetActive(true);


        //Move player and turn camera on
        player.transform.position = new Vector3(7.05f, 11.2f, 58.87559f);
        player.transform.GetChild(7).gameObject.SetActive(true);


        //Set rocket smoking & activate music
        rocket.transform.GetChild(8).gameObject.SetActive(false);
        rocket.transform.GetChild(10).gameObject.SetActive(true);
        music.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("m"))
        {
            SkipCutscene();
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
            if (!FindObjectOfType<DialogueManager>().IsTalking()) {
                if (Input.GetButtonDown("Interact") && !oneDialogue) {
                    
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




