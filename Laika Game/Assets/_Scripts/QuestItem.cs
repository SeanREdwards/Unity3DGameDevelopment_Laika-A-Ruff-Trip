using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour
{

    public GameObject player;
    public int questIndex;
    AudioSource audS;
    // Start is called before the first frame update
    void Start()
    {
        audS = this.GetComponent<AudioSource>();
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
            audS.Play();
            Invoke("DestroySelf", 0.5f);
        }
    }

    void DestroySelf()
    {
        Destroy(transform.gameObject);
    }
}
