using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePause : MonoBehaviour
{
    public GameObject pause, questLog;
    public CanvasGroup pauseMenu;

    public void TurnOnPause()
    {
        //pause.GetComponent<PauseScript>().Pause();
        pauseMenu.alpha = 1f;
        pauseMenu.blocksRaycasts = true;
        questLog.SetActive(false);
    }
}
