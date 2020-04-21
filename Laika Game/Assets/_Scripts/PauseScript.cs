using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{

    public static bool isPaused = false;
    public bool paused = false;
    public GameHandler Game;
    public GameObject PauseMenu;
    public GameObject PauseButtons;
    public GameObject options;
    public GameObject minimap;
    public GameObject reset;
    public GameObject controls;
    public GameObject talktip;
    public GameObject pickuptip;
    bool resettalk = false;
    bool resetpickup = false;

    private void Awake()
    {
        paused = false;
    }

    private void Start()
    {
       minimap = GameObject.Find("Quest and Map Canva");
        paused = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cancel")) {
            if (isPaused) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Resume() {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        paused = false;
        if (minimap != null)
        {
            minimap.SetActive(true);
        }

        if (resettalk)
        {
            resettalk = false;
            talktip.SetActive(true);

        }

        if (resetpickup)
        {
            resetpickup = false;
            pickuptip.SetActive(true);
        }
    }

    public void Pause() {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        paused = true;
        if (minimap != null)
        {
            minimap.SetActive(false);
        }

        if (talktip.gameObject.activeSelf)
        {
            talktip.SetActive(false);
            resettalk = true;
        }

        if (pickuptip.gameObject.activeSelf)
        {
            pickuptip.SetActive(false);
            resetpickup = true;
        }
    }

    public void OptionsButton() {
        OpenOptions();
    }

    public void ReturnButton() {
        CloseOptions();
    }

    public void OpenOptions() {
        PauseButtons.SetActive(false);
        options.SetActive(true);
    }

    public void CloseOptions() {
        options.SetActive(false);
        PauseButtons.SetActive(true);
    }

    public void OpenControls()
    {

        if (minimap != null)
        {
            minimap.SetActive(false);
        }


        controls.SetActive(true);
        PauseMenu.SetActive(false);
    }

    public void CloseControls()
    {
        if (minimap != null)
        {
            minimap.SetActive(true);
        }


        controls.SetActive(false);
        PauseMenu.SetActive(true);
    }

    public void Quit() {
        Game.Save();
        PauseMenu.SetActive(false);
        SceneManager.LoadScene(1);
    }

}
