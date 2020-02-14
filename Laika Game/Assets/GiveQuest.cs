using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiveQuest : MonoBehaviour
{
    public Quest quest;
    public GameObject player;
    public GameObject questWindow;
    public Text questTitleText;
    public Text questDescriptionText;
    public bool isQuestGiver = true;
    public bool questGiven = false;
    public int questIndex;


    public void AcceptQuest()
    {
        questWindow.SetActive(false);
        quest.isActive = true;
        player.GetComponent<QuestHolder>().quests.Add(quest);
        quest.questIndex = player.GetComponent<QuestHolder>().quests.Count-1;
        player.gameObject.GetComponent<PlayerMovementController>().enabled = true;
        GameObject questItem = Instantiate(quest.collectibleItem, quest.itemSpawn, Quaternion.identity);
        questItem.GetComponent<QuestItem>().questIndex = quest.questIndex;
        print(player.name);
        transform.GetComponent<Quest2_Dialogue>().questIndex = quest.questIndex;

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
