using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollHats : MonoBehaviour
{
    int i;
    public Text text;
    public string ogText;
    // Start is called before the first frame update
    void Start()
    {
        i = 0;

        ogText = text.text;
    }

    void SetHatsInactive()
    {
        for(int j = 0; j < transform.childCount; j++)
        {
            transform.GetChild(j).gameObject.SetActive(false);
        }
    }

    void ResetText()
    {
        text.text = ogText;
        while (text.text.Contains("<b>") || text.text.Contains("</b>")){
            text.text = text.text.Replace("<b><color=#ffa500ff><size=25>", "");
            text.text = text.text.Replace("</size></color></b>", "");

        }
    }

    public void NextHat()
    {
        SetHatsInactive();
        ResetText();
        GameObject hat = transform.GetChild(i).gameObject;
        int count = 0;
        while (!hat.GetComponent<IsBought>().isBought)
        {
            i += 1;
            i = i % transform.childCount;
            hat = transform.GetChild(i).gameObject;
            if(count > transform.childCount)
            {
                break;
            }
            count += 1;
        }

        if (count < transform.childCount)
        {
            hat.SetActive(true);
            
            text.text = text.text.Replace(hat.gameObject.name, "<b><color=#ffa500ff><size=25>" + hat.gameObject.name+"</size></color></b>");
        }
        

        i += 1;
        i = i % transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
