using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ResetLevel : MonoBehaviour
{

    public GameObject talktip;
    public GameObject pickuptip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            DontDestroyOnLoad(this);
            talktip.SetActive(false);
            pickuptip.SetActive(false);
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }

    }
}
