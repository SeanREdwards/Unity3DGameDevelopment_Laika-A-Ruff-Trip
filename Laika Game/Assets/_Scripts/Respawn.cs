using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject waterSplash;
    private Vector3 originalPos;
    private Quaternion originalRot;
    // Records the original position of the object to respawn
    void Start()
    {

        originalPos = transform.position;
        originalRot = transform.rotation;
    }

    //If this object enters a trigger
    private void OnTriggerEnter(Collider other)
    {
        //If object enters the water floor
        if(other.gameObject.name == "WaterFloor" || other.gameObject.tag == "Respawn")
        {
            transform.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            if(waterSplash != null) waterSplash.SetActive(true); //Play water splash sound effect
            Invoke("spawn", 1.5f); //Respawn in 1.5s
        }
    }

    void spawn()
    {
        transform.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        transform.rotation = originalRot;
        transform.position = originalPos; //Puts object back at original position
        if (waterSplash != null)  waterSplash.SetActive(false); //Readies water splash sound effect for next occurrence
    }
}
