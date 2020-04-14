using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechanicDialogueUpdater : MonoBehaviour
{
    GameObject laika;
    List<Quest> quests;
    int completeCount = 0;
    bool updated = false;
    bool onePress = false;
    [HideInInspector]
    public bool dialogueEnded = false;
    public GameObject nextLevelWindow;
    // Start is called before the first frame update
    void Start()
    {
        laika = GameObject.Find("Player");
        quests = laika.GetComponent<QuestHolder>().quests;
    }

    public void Yes_NextLevel()
    {
        if (!onePress)
        {
            laika.transform.GetChild(8).gameObject.SetActive(true);
            laika.GetComponentInChildren<LoadNextScene>().NextScene();
            nextLevelWindow.SetActive(false);
        }
        onePress = true;

    }

    public void No_NextLevel()
    {
        nextLevelWindow.SetActive(false);
    }

    void CheckForTwoCompleteQuests()
    {
        completeCount = 0;
        for(int i = 0; i < quests.Count; i++)
        {
            if (quests[i].complete)
            {
                completeCount += 1;
            }
        }

        if(completeCount >= 2)
        {
            print(completeCount);
            updated = true;
            
            GetComponent<JailedNPCDialogue>().updateDialogue();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueEnded && updated)
        {
            dialogueEnded = false;
            nextLevelWindow.SetActive(true);

        } else if (dialogueEnded)
        {
            dialogueEnded = false;
        }

        if (!updated)
        {
            CheckForTwoCompleteQuests();
        }
    }
}
