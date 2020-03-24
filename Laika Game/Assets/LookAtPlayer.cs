using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class LookAtPlayer : MonoBehaviour
{
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        GetComponent<CinemachineVirtualCamera>().LookAt = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
