using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Applied to big trigger on the bottom of the map. If laika enters this trigger, reloads level
public class Restart_Ast : MonoBehaviour
{
    public GameObject prefab, failText;
    GameObject laika;
    public Collider toRespawn;
    public Animator animator;
    GameObject complete;
    private void Start()
    {
        laika = GameObject.Find("Player");
        complete = GameObject.Find("CompleteRestart_Ast");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Laika")
        {
            other.gameObject.GetComponent<Animator>().SetTrigger("Death");
            complete.GetComponent<CompleteRestart_Ast>().FadeBlack();
        }
    }

}
