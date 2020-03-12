using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartingSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject player  = GameObject.Find("Player");
        player.transform.position = transform.position;
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
