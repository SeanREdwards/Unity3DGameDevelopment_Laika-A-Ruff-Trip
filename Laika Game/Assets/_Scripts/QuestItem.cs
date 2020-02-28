using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour
{
    GameObject sfx;

    public int questIndex;
    // Start is called before the first frame update
    void Start()
    {
        sfx = GameObject.Find("CollectSoundEffect");

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Laika")
        {
            sfx.GetComponent<PlayCollectSoundEffect>().play = true;

            other.gameObject.transform.parent.GetComponent<QuestHolder>().quests[questIndex].gotItem = true;
            other.gameObject.transform.parent.GetComponent<QuestHolder>().quests[questIndex].QuestGiver.GetComponent<Quest_Dialogue_Logic>().UpdateDialogue_QuestFinished_BeforeReward();
            Destroy(transform.gameObject);
        }
    }
}
