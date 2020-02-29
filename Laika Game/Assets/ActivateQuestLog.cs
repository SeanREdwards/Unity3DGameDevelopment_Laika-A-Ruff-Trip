using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateQuestLog : MonoBehaviour
{

    public GameObject QuestLog;

    public void TurnOnQuestLog()
    {
        QuestLog.SetActive(true);
        this.transform.GetChild(0).gameObject.SetActive(false);
        QuestLog.GetComponentInChildren<QuestLogDisplay>().Populate();
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
