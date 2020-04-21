using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinaleCutscene : MonoBehaviour
{
    public GameObject finalCam, laikaGif, logo;
    GameObject player;
    public Animator animator;
    public GameObject fin;
    public Text t;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Laika")
        {
            StartFinale();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartFinale()
    {
        player.SetActive(false);
        animator.SetTrigger("FadeOut");
        Invoke("CameraSwitch", 1f);
    }

    void CameraSwitch()
    {
        finalCam.SetActive(true);
        Invoke("RocketStart", 1.3f);
    }

    void RocketStart()
    {
        GetComponent<Animator>().enabled = true;
        GetComponent<Animator>().SetTrigger("RocketMove");
        animator.SetTrigger("FadeIn");

        Invoke("ToEarth", 2f);
    }

    void ToEarth()
    {
        transform.GetChild(8).gameObject.SetActive(false);
        transform.GetChild(9).gameObject.SetActive(true);
        GetComponent<Animator>().SetTrigger("RocketToEarth");
        Invoke("LastStretch", 2f);
        GetComponent<AudioSource>().Play();
    }

    void LastStretch()
    {
        GetComponent<Animator>().SetTrigger("LastStretch");
        Invoke("FadeBlack", 1f);

    }
    
    void FadeBlack()
    {
        animator.SetTrigger("FadeOutSlow");
        Invoke("Fin", 4.7f);
    }

    void Fin()
    {
        fin.SetActive(true);
        laikaGif.SetActive(true);
        logo.SetActive(true);
        animator.SetTrigger("FadeIn");
        StartCoroutine(FadeTextToFullAlpha(1f, t));
        StartCoroutine(FadeImageToFullAlpha(1f, laikaGif.GetComponent<Image>()));
        StartCoroutine(FadeImageToFullAlpha(1f, logo.GetComponent<Image>()));
        Invoke("Quit", 4.75f);
    }

    void Quit()
    {
        //Application.Quit();
        print("QUIT");
        player.SetActive(true);
        DontDestroyOnLoad(player);
        //player.transform.GetChild(10).GetComponent<PauseScript>().Quit();
        SceneManager.LoadScene(1);

    }

    public IEnumerator FadeTextToFullAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }

    public IEnumerator FadeImageToFullAlpha(float t, Image i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }

}
