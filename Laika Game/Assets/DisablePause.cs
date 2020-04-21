using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablePause : MonoBehaviour
{

    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        player.transform.GetChild(10).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
