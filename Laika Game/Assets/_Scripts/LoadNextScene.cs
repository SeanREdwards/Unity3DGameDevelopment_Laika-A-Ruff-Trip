using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadNextScene : MonoBehaviour
{
    public Slider slider;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        print("Have I mad e it here?");
        StartCoroutine(LoadNewScene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LoadNewScene()
    {
        print("Made it into here here");
        slider.gameObject.SetActive(true);
        text.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.2f);
        AsyncOperation async = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        //animator.SetTrigger("FadeIn");
        while (!async.isDone)
        {
            float progress = Mathf.Clamp01(async.progress / .9f);
            slider.value = progress;
            float print = progress * 100f;
            print = Mathf.RoundToInt(print);
            text.text = print + "%";
            yield return null;           
        }
    }

}
