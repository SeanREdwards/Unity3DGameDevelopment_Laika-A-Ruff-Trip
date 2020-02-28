using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestReward : MonoBehaviour
{
    GameObject sfx;
    void Start()
    {
        sfx = GameObject.Find("CollectSoundEffect");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Laika")
        {
            sfx.GetComponent<PlayCollectSoundEffect>().play = true;
            Destroy(transform.gameObject);
        }
    }
}
