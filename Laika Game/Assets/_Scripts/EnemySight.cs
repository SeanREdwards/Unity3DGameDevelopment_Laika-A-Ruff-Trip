using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySight : MonoBehaviour
{

    public GameObject excl;
    public GameObject player;

    private NavMeshAgent agent;
    public GameObject npc;
    private bool IsChasing;
    // Start is called before the first frame update
    void Start()
    {
        agent = npc.GetComponent<NavMeshAgent>();
        agent.destination = agent.transform.position;
        IsChasing = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        agent.destination = IsChasing ? player.transform.position : agent.transform.position;
        
        Vector3 targetDirection = player.transform.position - transform.parent.transform.position;
        float singleStep = 2.0f * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.parent.transform.forward, targetDirection, singleStep, 0.0f);
        transform.parent.transform.rotation = Quaternion.LookRotation(newDirection);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("Laika"))
        {
            excl.SetActive(true);
            IsChasing = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Vector3 targetDirection = player.transform.position - transform.parent.transform.position;
        float singleStep = 2.0f * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.parent.transform.forward, targetDirection, singleStep, 0.0f);
        transform.parent.transform.rotation = Quaternion.LookRotation(newDirection);
    }

    private void OnTriggerExit(Collider other)
    {
        excl.SetActive(false);
        if (other.gameObject.name.Equals("Laika"))
        {
            excl.SetActive(false);
            IsChasing = false;
        }
    }



}
