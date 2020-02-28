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
    private bool inCutscene;
    private bool oneDialogue = false;
    public string questTitle_ToUpdate;

    public GameObject skipText;
    public GameObject shakeWindow, cameraShaker;
    public GameObject skipWindow;
    public GameObject playerCam, doorCam, rocketCrashCam, cinemachineBrain;
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

    public void EndDialogue()
    {
        FindObjectOfType<DialogueManager>().EndDialogue();
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

    public void SkipCutsceneButton()
    {
        SkipCutscene();
        skipWindow.SetActive(false);
        Time.timeScale = 1;
    }

    public void DontSkipCutsceneButton()
    {
        skipWindow.SetActive(false);
        Time.timeScale = 1;
    }

    void PlayerControl()
    {
        rocketCrashCam.SetActive(false);
        if (inCutscene)
        {
            player.transform.position = new Vector3(7.05f, 11.2f, 58.87559f);
        }
        player.transform.GetChild(7).gameObject.SetActive(true);
        Invoke("FinalRocketExplosion", 4f);
        rocket.transform.GetChild(9).gameObject.SetActive(false);
        explosionSound.SetActive(false);
        inCutscene = false;

    }
    
    void FinalRocketExplosion()
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

    void Start()
    {
        //Invoke("BeginDialogue", 3f);
        Time.timeScale = 0;
        originalRot = transform.rotation;
        sentencesNum = dialogue.sentences.Length;
        player = GameObject.Find("Player");
        q = player.GetComponent<QuestHolder>().quests;
        d = Vector3.Distance(player.transform.position, transform.position);
        TalkDistance = 500;


    }

    public void ShakeOn()
    {
        shakeWindow.SetActive(false);
        cameraShaker.GetComponent<CameraShakeContinuous>().enabled = true;
        Invoke("BeginDialogue", 3f);
        rocketFlyingSound.SetActive(true);
        alarmSound.SetActive(true);
        Time.timeScale = 1;

    }

    public void ShakeOff()
    {
        shakeWindow.SetActive(false);
        cameraShaker.GetComponent<CameraShakeContinuous>().enabled = false;
        Invoke("BeginDialogue", 3f);
        rocketFlyingSound.SetActive(true);
        alarmSound.SetActive(true);
        Time.timeScale = 1;


    }

    void BeginDialogue()
    {
        skipText.SetActive(true);
        TriggerDialogue();
        oneDialogue = true;
        playerCam.SetActive(false);
        inCutscene = true;
    }

    void SkipCutscene()
    {
        print("SKIPPING");
        inCutscene = false;
        CancelInvoke();

        //Set Cinemachine brain to cut blend
        cinemachineBrain.GetComponent<CinemachineBrain>().m_DefaultBlend.m_Style = CinemachineBlendDefinition.Style.Cut;

        //Stop animations
        rocket.GetComponent<Animator>().enabled = false;

        //Turn off alarm and rocket flying sound
        rocketFlyingSound.SetActive(false);
        alarmSound.SetActive(false);

        //End dialogue
        EndDialogue();

        //Move rocket
        rocket.transform.position = new Vector3(10.06f, 11.6f, 57.85f);

        //Set rocket smoking
        rocket.transform.GetChild(8).gameObject.SetActive(false);
        rocket.transform.GetChild(10).gameObject.SetActive(true);


        //Enable crash landing spot
        crashLandingSpot.SetActive(true);


        //Move Laika and turn camera on
        player.transform.position = new Vector3(7.05f, 11.2f, 58.87559f);
        player.transform.GetChild(7).gameObject.SetActive(true);

        //Activate music
        music.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        if (!inCutscene)
        {
            skipText.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Backspace) && inCutscene)
        {
            skipWindow.SetActive(true);
            Time.timeScale = 0;
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




