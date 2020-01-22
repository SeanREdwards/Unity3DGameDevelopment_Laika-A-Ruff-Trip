using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour
{

    public GameObject excl;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("Player"))
        {
            excl.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Vector3 targetDirection = player.transform.position - transform.parent.transform.position;
        float singleStep = 1.0f * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.parent.transform.forward, targetDirection, singleStep, 0.0f);
        transform.parent.transform.rotation = Quaternion.LookRotation(newDirection);

    }

    private void OnTriggerExit(Collider other)
    {
        excl.SetActive(false);
        print("huh");
    }



}
