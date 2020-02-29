using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestLogDisplay : MonoBehaviour
{

    public GameObject player;
    public GameObject prefab;
    QuestHolder qh;
    List<Quest> ls;
    // Start is called before the first frame update
    void Start()
    {
        qh = player.GetComponent<QuestHolder>();
        ls = qh.quests;
    }

    private void Awake()
    {

        qh = player.GetComponent<QuestHolder>();
        ls = qh.quests;
    }

    public void Populate()
    {

        for(int i = 5; i < this.transform.childCount-3; i++)
        {
            Destroy(this.transform.GetChild(i).gameObject);

        }

        for(int i =0; i < ls.Count; i++)
        {
            GameObject newObj;
            //Print quest title
            newObj = (GameObject)Instantiate(prefab, transform);
            newObj.gameObject.GetComponent<Text>().text = ls[i].title;
            newObj.transform.SetSiblingIndex(transform.childCount - 4);

            //Print quest giver name
            newObj = (GameObject)Instantiate(prefab, transform);
            newObj.gameObject.GetComponent<Text>().text = ls[i].giverName;
            newObj.transform.SetSiblingIndex(transform.childCount - 4);


            //Print quest objective
            newObj = (GameObject)Instantiate(prefab, transform);
            newObj.gameObject.GetComponent<Text>().text = ls[i].objective;
            newObj.gameObject.GetComponent<Text>().fontSize = 16;
            newObj.transform.SetSiblingIndex(transform.childCount - 4);

            //Print out got item
            newObj = (GameObject)Instantiate(prefab, transform);
            if (ls[i].gotItem)
            {
                newObj.gameObject.GetComponent<Text>().text = "O";
            } else
            {
                newObj.gameObject.GetComponent<Text>().text = "X";
            }
            newObj.gameObject.GetComponent<Text>().fontSize = 30;
            newObj.transform.SetSiblingIndex(transform.childCount - 4);

            //Print quest complete status
            newObj = (GameObject)Instantiate(prefab, transform);
            if (ls[i].complete)
            {
                newObj.gameObject.GetComponent<Text>().text = "O";
            } else
            {
                newObj.gameObject.GetComponent<Text>().text = "X";
            }
            newObj.gameObject.GetComponent<Text>().fontSize = 30;
            newObj.transform.SetSiblingIndex(transform.childCount - 4);


        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("b")) { Populate(); }
    }
}
