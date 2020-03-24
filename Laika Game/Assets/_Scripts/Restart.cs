using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Applied to big trigger on the bottom of the map. If laika enters this trigger, reloads level
public class Restart : MonoBehaviour
{
    public GameObject prefab, failText;
    GameObject laika;
    public Collider toRespawn;
    public Animator animator;

    private void Start()
    {
        laika = GameObject.Find("Player");
        animator = GameObject.Find("LevelChanger").GetComponent<Animator>();
        failText = GameObject.Find("FailureText");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Laika")
        {
            other.gameObject.GetComponent<Animator>().SetTrigger("Death");
            FadeBlack();
        }
    }

    void FadeBlack()
    {
        animator.SetTrigger("FadeOut");
        Invoke("TryAgainText", 1f);
    }

    void TryAgainText()
    {
        failText.SetActive(true);
        StartCoroutine(FadeTextToFullAlpha(1f, failText.GetComponent<Text>()));
        Invoke("Reload", 1f);
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


    void Reload()
    {
        DontDestroyOnLoad(laika);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        laika.transform.GetChild(1).GetComponent<Animator>().SetTrigger("Reset");
    }
}
