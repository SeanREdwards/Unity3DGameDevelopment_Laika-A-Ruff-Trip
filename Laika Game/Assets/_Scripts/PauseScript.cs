using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{

    public static bool isPaused = false;
    public GameHandler Game;
    public GameObject PauseMenu;
    public GameObject PauseButtons;
    public GameObject options;
    public GameObject minimap;
    public GameObject reset;

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
        if (minimap != null)
        {
            minimap.SetActive(true);
        }
    }

    public void Pause() {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        if (minimap != null)
        {

            minimap.SetActive(false);
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

    public void Quit() {
        Game.Save();
        PauseMenu.SetActive(false);
        SceneManager.LoadScene(1);
    }

}
