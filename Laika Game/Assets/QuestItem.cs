using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour
{

    public GameObject player;
    public int questIndex;
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
        if (other.gameObject.name == "Laika")
        {
            other.gameObject.transform.parent.GetComponent<QuestHolder>().quests[questIndex].gotItem = true;
            other.gameObject.transform.parent.GetComponent<QuestHolder>().quests[questIndex].QuestGiver.GetComponent<Quest2_Dialogue>().UpdateDialogue_QuestFinished_BeforeReward();
            Destroy(transform.gameObject);
        }
    }
}
