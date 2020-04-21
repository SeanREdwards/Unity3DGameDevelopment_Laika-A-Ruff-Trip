using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostFocus : MonoBehaviour
{
    bool isPaused = false;
    AudioSource ads, ads2;
    AudioSource[] allAudio;
    public GameObject pause;
    void Start()
    {

        allAudio = FindObjectsOfType<AudioSource>();
        
    }

    void OnApplicationFocus(bool hasFocus)
    {
        isPaused = !hasFocus;

    }

    void OnApplicationPause(bool pauseStatus)
    {
        isPaused = pauseStatus;

    }


    // Update is called once per frame
    void Update()
    {
        if (isPaused)
        {
            Time.timeScale = 0f;
        } else if(!isPaused && !pause.activeSelf)
        {
            Time.timeScale = 1f;
        }
        
    }
}
