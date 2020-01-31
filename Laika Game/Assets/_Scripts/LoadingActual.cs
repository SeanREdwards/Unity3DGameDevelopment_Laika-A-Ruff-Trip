using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingActual : MonoBehaviour
{
    private bool loadScene = false;
    private bool oneInvoke = true;
    [SerializeField]
    private int scene;
    [SerializeField]
    private Text loadingText;
    public GameObject ImagesParent;
    private Image image;
    private int childIndex = 0;
    private int numOfImages;
    public GameObject loadingScreen;
    public Slider slider;
    public Text text;
    public GameObject spaceNoise;
    public GameObject laikaRun;
    public Animator animator;


    private void Start()
    {
        Transform[] allChildren = ImagesParent.GetComponentsInChildren<Transform>();
        numOfImages = allChildren.Length-1;
        print(numOfImages);
        for(int i = 1; i < allChildren.Length - 1; i++)
        {
            ImagesParent.transform.GetChild(i).GetComponent<Image>().CrossFadeAlpha(0, 0, false);
        }
    }

    void Update()
    {

        if (Input.GetKeyUp(KeyCode.Space) && loadScene == false)
        {
            

            StartCoroutine(LoadNewScene());

        }

        if (loadScene == true)
        {
            spaceNoise.SetActive(true);
            laikaRun.SetActive(true);

            loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b, Mathf.PingPong(Time.time, 1));
            if (oneInvoke)
            {
                oneInvoke = false;
                InvokeRepeating("fadeOut", 0, 2.1f);
            }
        }

    }

    void fadeOut()
    {
        image = ImagesParent.transform.GetChild(childIndex).GetComponent<Image>();
        image.CrossFadeAlpha(0, 0.7f, false);
        Invoke("fadeIn", 0.7f);

    }

    void fadeIn()
    {
        childIndex = (childIndex + 1) % numOfImages;
        
        image = ImagesParent.transform.GetChild(childIndex).GetComponent<Image>();
        print("Fading in " + image.name);
        image.CrossFadeAlpha(1, 0.7f, false);
    }

    IEnumerator LoadNewScene()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(scene);
        loadingText.text = "Loading...";

        //animator.SetTrigger("FadeOut");
        loadScene = true;
        loadingScreen.SetActive(true);
        //animator.SetTrigger("FadeIn");

        while (!async.isDone)
        {
            float progress = Mathf.Clamp01(async.progress / .9f);
            slider.value = progress;
            text.text = progress * 100f + "%";
            yield return null;
        }
        animator.SetTrigger("FadeOut");

    }

}
