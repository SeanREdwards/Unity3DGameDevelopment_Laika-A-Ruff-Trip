using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartingSpawn : MonoBehaviour
{
    public bool fixedCameraLevel;
    public bool startCursorVisible;
    //public bool visibleCursor;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player  = GameObject.Find("Player");
        player.transform.position = transform.position;
        player.transform.GetChild(10).gameObject.SetActive(true);
        player.transform.GetChild(4).gameObject.SetActive(true);
        player.transform.GetChild(1).gameObject.GetComponent<BoxCollider>().enabled = true;
        player.transform.GetChild(5).GetChild(1).GetChild(0).gameObject.SetActive(true);

        if (fixedCameraLevel)
        {
            player.transform.GetChild(6).gameObject.SetActive(false);
        } else
        {
            player.transform.GetChild(6).gameObject.SetActive(true);

        }

        if (!startCursorVisible)
        {
            Cursor.visible = false;
        }

        /*
        if (visibleCursor)
        {
            Cursor.visible = true;
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
