using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{

    public GameObject menu;
    public GameObject options;

    public void PlayButton() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OptionsButton() {
        OpenOptions();
    }

    public void QuitButton() {
        Application.Quit();
    }

    public void ReturnButton() {
        CloseOptions();
    }

    public void OpenOptions() {
        menu.SetActive(false);
        options.SetActive(true);
    }

    public void CloseOptions() {
        options.SetActive(false);
        menu.SetActive(true);
    }
}
