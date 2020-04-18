using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostFocus : MonoBehaviour
{
    bool isPaused = false;
    public GameObject source, source2;
    AudioSource ads, ads2;

    void Start()
    {
        ads = source.GetComponent<AudioSource>();
        if (ads2 != null)
        {
            ads2 = source2.GetComponent<AudioSource>();
        }
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
            if (ads2 != null)
            {
                ads2.Pause();
            }
        } else
        {
            Time.timeScale = 1f;
            if (!ads.isPlaying)
            {
                ads.Play();
            }
            if (ads2 != null)
            {
                if (!ads2.isPlaying)
                {
                    ads2.Play();
                }
            }
        }
    }
}
