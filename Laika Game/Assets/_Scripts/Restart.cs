using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Applied to big trigger on the bottom of the map. If laika enters this trigger, reloads level
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
