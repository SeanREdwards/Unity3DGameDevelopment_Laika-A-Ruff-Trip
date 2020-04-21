using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartingSpawn : MonoBehaviour
{
    public bool fixedCameraLevel;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player  = GameObject.Find("Player");
        player.transform.position = transform.position;

        player.transform.GetChild(4).gameObject.SetActive(true);


        if (fixedCameraLevel)
        {
            player.transform.GetChild(6).gameObject.SetActive(false);
        } else
        {
            player.transform.GetChild(6).gameObject.SetActive(true);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
