using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestReward : MonoBehaviour
{
    AudioSource audS;
    void Start()
    {
        audS = this.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Laika")
        {
            audS.Play();
            Invoke("DestroySelf", 0.5f);
        }
    }

    void DestroySelf()
    {
        Destroy(transform.gameObject);
    }
}
