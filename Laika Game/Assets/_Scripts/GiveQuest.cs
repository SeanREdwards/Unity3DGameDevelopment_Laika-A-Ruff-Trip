using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiveQuest : MonoBehaviour
{
    public Quest quest;
    GameObject player;
    public GameObject questWindow;
    public Text questTitleText;
    public Text questDescriptionText;
    [HideInInspector]
    public bool isQuestGiver = true;
    [HideInInspector]
    public bool questGiven = false;
    [HideInInspector]
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
        player = GameObject.Find("Player_UpToDate");
        quest.QuestGiver = transform.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
