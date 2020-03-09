using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    private bool loadScene = false;
    private bool oneInvoke = true;
    [SerializeField]
    public int scene = 1;
    [SerializeField]
    public Text loadingText;
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
        animator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1f);
        loadScene = true;
        loadingText.text = "Loading...";
        loadingScreen.SetActive(true);
        animator.SetTrigger("FadeIn");

        
        for(float f = 0.0f; f <= 1.0f; f = f + 0.05f)
        {
            yield return new WaitForSeconds(0.5f);
            slider.value = f;
            float print = f * 100f;
            print = Mathf.RoundToInt(print);
            text.text = print + "%";

        }

        yield return new WaitForSeconds(2f);
        slider.value = 1f;
        text.text = "100%";

        /*
        yield return new WaitForSeconds(1f);
        slider.value = 0.1f;
        text.text = "10%";
        yield return new WaitForSeconds(1f);
        text.text = "20%";
        slider.value = 0.2f;


        yield return new WaitForSeconds(1f);
        text.text = "30%";
        slider.value = 0.3f;

        yield return new WaitForSeconds(1f);
        text.text = "40%";
        slider.value = 0.4f;

        yield return new WaitForSeconds(1f);
        text.text = "50%";
        slider.value = 0.5f;

        yield return new WaitForSeconds(1f);
        text.text = "60%";
        slider.value = 0.6f;

        yield return new WaitForSeconds(1f);
        text.text = "70%";
        slider.value = 0.7f;

        yield return new WaitForSeconds(1f);
        text.text = "80%";
        slider.value = 0.8f;

        yield return new WaitForSeconds(1f);
        text.text = "90%";
        slider.value = 0.9f;

        yield return new WaitForSeconds(1f);
        text.text = "100%";
        slider.value = 1f;
        */
        /*
        yield return new WaitForSeconds(4f);
        slider.value = 0.93f;
        text.text = "93%";
        yield return new WaitForSeconds(2f);
        slider.value = 1f;
        text.text = "100%";
        */
        animator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(2);
        AsyncOperation async = SceneManager.LoadSceneAsync(scene);

        while (!async.isDone)
        {
            yield return null;
        }

    }

}
