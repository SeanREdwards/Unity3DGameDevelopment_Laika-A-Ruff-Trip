using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject waterSplash;
    private Vector3 originalPos;
    // Records the original position of the object to respawn
    void Start()
    {
        originalPos = transform.position;
    }

    //If this object enters a trigger
    private void OnTriggerEnter(Collider other)
    {
        //If object enters the water floor
        if(other.gameObject.name == "WaterFloor")
        {
            waterSplash.SetActive(true); //Play water splash sound effect
            Invoke("spawn", 1.5f); //Respawn in 1.5s
        }
    }

    void spawn()
    {
        transform.position = originalPos; //Puts object back at original position
        waterSplash.SetActive(false); //Readies water splash sound effect for next occurrence
    }
}
