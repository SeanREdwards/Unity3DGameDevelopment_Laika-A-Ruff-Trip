using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNextLevelTrigger : MonoBehaviour
{
    public GameObject loadNextScene;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Laika")
        {
            print(loadNextScene.name);

            loadNextScene.SetActive(true);
        }
    }
}
