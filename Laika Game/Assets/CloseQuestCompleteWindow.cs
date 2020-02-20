using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseQuestCompleteWindow : MonoBehaviour
{


    public void closeWindow()
    {
        this.transform.parent.gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
