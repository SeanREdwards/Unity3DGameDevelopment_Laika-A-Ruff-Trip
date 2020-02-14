using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public bool isActive;
    public string title;
    public string description;
    public Vector3 itemSpawn;
    public GameObject collectibleItem;
    public bool gotItem = false;
    public int questIndex;
    public GameObject QuestGiver;
    public bool rewardReceived = false;
    public bool complete;
}
