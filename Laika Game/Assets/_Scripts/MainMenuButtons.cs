using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{

    public GameObject menu;
    public GameObject options;
    public GameHandler Game;
    public GameObject laika;
    public GameObject reset;
    private void Start() {
        Time.timeScale = 1;
        laika = GameObject.Find("Player");
        Game = laika.GetComponent<GameHandler>();

    }

    public void PlayButton() {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //print(laika.name);
        laika.GetComponentInChildren<LoadNextScene>().NextScene();
        //DontDestroyOnLoad(laika);
        reset.SetActive(true);
        

    }

    public void LoadButton() {
        Game.LoadScene();
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
