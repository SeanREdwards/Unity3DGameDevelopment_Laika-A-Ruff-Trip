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
        OnScreen = transform.GetChild(index % transform.childCount).localPosition;
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
        transform.GetChild(index % transform.childCount).localPosition = OnScreen;
    }

    IEnumerator LoadNewScene()
    {
        slider.gameObject.SetActive(true);
        text.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.1f);

        AsyncOperation async = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        //animator.SetTrigger("FadeIn");
        while (!async.isDone)
        {
            float progress = Mathf.Clamp01(async.progress / .9f);
            slider.value = progress;
            float print = progress * 100f;
            print = Mathf.RoundToInt(print);
            text.text = print+"%";
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
