using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePause : MonoBehaviour
{
    public GameObject pause, questLog;

    public void TurnOnPause()
    {
        pause.GetComponent<PauseScript>().Pause();
        questLog.SetActive(false);
    }
}
