using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiveQuest : MonoBehaviour
{
    public Quest quest;
    GameObject player;
    public GameObject questWindow;
    Button button;
    [HideInInspector]
    public bool isQuestGiver = true;
    [HideInInspector]
    public bool questGiven = false;
    [HideInInspector]
    public int questIndex;
    [HideInInspector]
    public bool dialogueEnded = false;
    GameObject talktip;



    public void AcceptQuest()
    {

        questWindow.SetActive(false);
        quest.isActive = true;
        player.GetComponent<QuestHolder>().quests.Add(quest);
        quest.questIndex = player.GetComponent<QuestHolder>().quests.Count-1;
        player.gameObject.GetComponent<PlayerMovementController>().enabled = true;
        SpawnItem(0);
        transform.GetComponent<Quest_Dialogue_Logic>().questIndex = quest.questIndex;

    }

    public void SpawnItem(int i)
    {
        GameObject questItem = Instantiate(quest.collectibleItem, quest.itemSpawnLocation.transform.position, Quaternion.identity);
        if (i != 1) { questItem.GetComponent<QuestItem>().questIndex = quest.questIndex; }
    }

    public void UpdateWindow()
    {
        questWindow.SetActive(true);
        talktip.SetActive(false);

        questWindow.transform.GetChild(3).GetComponent<Text>().text = quest.completedTitle;
        questWindow.transform.GetChild(3).GetComponent<Text>().color = Color.white;

        questWindow.transform.GetChild(2).GetComponent<Text>().text = quest.completedDescription;
        questWindow.transform.GetChild(2).GetComponent<Text>().color = Color.white;

        //questTitleText.text = quest.completedTitle;
        //questDescriptionText.text = quest.completedDescription;
        button.GetComponent<Button>().onClick.RemoveAllListeners();
        button.GetComponentInChildren<Text>().text = "Close";

        button.GetComponent<Button>().onClick.AddListener(CloseWindow);

    }

    void CloseWindow()
    {
        questWindow.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        talktip = player.transform.GetChild(5).GetChild(2).gameObject;
        quest.QuestGiver = transform.gameObject;
        quest.giverName = transform.parent.gameObject.name;
        button = questWindow.transform.GetChild(1).GetComponent<Button>();
    }

    void BeginQuest()
    {

        questWindow.SetActive(true);
        talktip.SetActive(false);
        questWindow.transform.GetChild(3).GetComponent<Text>().text = quest.title;
        questWindow.transform.GetChild(3).GetComponent<Text>().color = Color.white;
        questWindow.transform.GetChild(2).GetComponent<Text>().text = quest.description;
        questWindow.transform.GetChild(2).GetComponent<Text>().color = Color.white;
        questIndex = quest.questIndex;
        GetComponent<Quest_Dialogue_Logic>().UpdateDialogue_QuestStarted();
        button.GetComponentInChildren<Text>().text = "Accept";
        button.GetComponent<Button>().onClick.RemoveAllListeners();

        button.GetComponent<Button>().onClick.AddListener(AcceptQuest);
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueEnded && !questGiven)
        {

            BeginQuest();
            questGiven = true;
            dialogueEnded = false;
        }
    }
}
