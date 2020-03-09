using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostFocus : MonoBehaviour
{
    bool isPaused = false;
    public GameObject source;
    AudioSource ads;

    void Start()
    {
        ads = source.GetComponent<AudioSource>();
        
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
            ads.Pause();
        } else
        {
            Time.timeScale = 1f;
            if (!ads.isPlaying)
            {
                ads.Play();
            }
        }
    }
}
