using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNextLevelTrigger : MonoBehaviour
{
    GameObject loadNextScene;
    // Start is called before the first frame update
    void Start()
    {
        loadNextScene = GameObject.Find("Player").transform.GetChild(8).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Laika")
        {

            loadNextScene.SetActive(true);

        }
    }
}
