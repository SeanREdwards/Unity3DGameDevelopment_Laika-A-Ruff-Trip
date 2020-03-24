using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevelTrigger : MonoBehaviour
{
    GameObject loadingBar;
    bool isColliding;
    // Start is called before the first frame update
    void Start()
    {
        loadingBar = GameObject.Find("Player").transform.GetChild(8).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Laika")
        {
            other.transform.parent.GetComponentInChildren<LoadNextScene>().NextScene();
            loadingBar.SetActive(true);

        }
    }
}
