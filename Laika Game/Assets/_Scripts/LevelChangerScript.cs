using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChangerScript : MonoBehaviour
{

    public Animator animator;
    private int level;

    public void fade()
    {
        animator.SetTrigger("FadeOut");
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButton() {
        FadeAndLoad(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitButton() {
        Application.Quit();
    }

    public void FadeAndLoad(int i) {
        animator.SetTrigger("FadeOut");
        level = i;
        SceneManager.LoadScene(level);
    }


}
