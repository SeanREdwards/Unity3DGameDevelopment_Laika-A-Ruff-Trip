﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;
    Resolution[] resolutions;
    public Dropdown resolutionDropdown;

    void Start()
    {
        //resolutions = Screen.resolutions;
        //resolutionDropdown.ClearOptions();
        QualitySettings.SetQualityLevel(5);

        List<string> options = new List<string>();
        /*
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
        }
        */
        //resolutionDropdown.AddOptions(options); //list

    }

    public void SetVolume(float vol) {
        vol = vol / 2.5f;
        audioMixer.SetFloat("Volume", vol);

    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        
    }
}
