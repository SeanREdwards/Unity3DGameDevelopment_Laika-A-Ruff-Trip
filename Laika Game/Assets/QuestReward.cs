using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestReward : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Laika")
        {
            Destroy(transform.gameObject);
        }
    }
}
