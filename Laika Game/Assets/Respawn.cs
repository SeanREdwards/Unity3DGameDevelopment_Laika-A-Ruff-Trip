using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject waterSplash;
    private Vector3 originalPos;
    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "WaterFloor")
        {
            waterSplash.SetActive(true);
            Invoke("spawn", 1.5f);
        }
    }

    void spawn()
    {
        transform.position = originalPos;
        waterSplash.SetActive(false);
    }
}
