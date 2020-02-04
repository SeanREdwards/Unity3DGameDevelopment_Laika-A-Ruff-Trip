using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Selector : MonoBehaviour
{
    private Vector3 OnScreen;
    private Vector3 OffScreen;
    private int index;
    public Slider slider;
    public Text text;
    public Button startButton;
    public Button nextButton;

    private void Awake()
    {
        index = 0;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LoadFirstScene()
    {
        startButton.gameObject.SetActive(false);
        nextButton.gameObject.SetActive(false);
        StaticVariableHolder.Material = index % transform.childCount;
        StartCoroutine(LoadNewScene());
        //AsyncOperation async = SceneManager.LoadSceneAsync(3);
    }

    public void NextLaika()
    {
        transform.GetChild(index % transform.childCount).localPosition = new Vector3(-5f, -5f, -5f);
        index = index + 1;
        transform.GetChild(index % transform.childCount).localPosition = new Vector3(-0.311f, 0f, 0.36f);
    }

    IEnumerator LoadNewScene()
    {
        slider.gameObject.SetActive(true);
        text.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.1f);

        AsyncOperation async = SceneManager.LoadSceneAsync(3);
        //animator.SetTrigger("FadeIn");
        while (!async.isDone)
        {
            float progress = Mathf.Clamp01(async.progress / .9f);
            slider.value = progress;
            text.text = progress * 100f + "%";
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
