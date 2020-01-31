using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public GameObject prefab;
    public Collider toRespawn;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Laika")
        {
            SceneManager.LoadScene(3);
        }

    }



}
