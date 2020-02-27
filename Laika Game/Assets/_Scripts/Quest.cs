using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    [HideInInspector]
    public bool isActive;
    public string title;
    public string description;
    public GameObject itemSpawnLocation;
    //public Vector3 itemSpawn;
    public GameObject collectibleItem;
    [HideInInspector]
    public bool gotItem = false;
    [HideInInspector]
    public int questIndex;
    [HideInInspector]
    public GameObject QuestGiver;
    [HideInInspector]
    public bool rewardReceived = false;
    [HideInInspector]
    public bool complete;
    public string completedTitle;
    public string completedDescription;
    
}
