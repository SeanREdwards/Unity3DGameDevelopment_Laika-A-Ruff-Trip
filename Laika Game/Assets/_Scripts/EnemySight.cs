using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySight : MonoBehaviour
{
    
    public GameObject excl;
    public List<GameObject> PatrolPoints;
    public GameObject sound;
    private NavMeshAgent agent;
    private INPCState CurrentBehavior;
    private int PatrolReturn;

    // Start is called before the first frame update
    void Start()
    {
        PatrolReturn = 0;
        agent = transform.parent.GetComponent<NavMeshAgent>();
        agent.destination = agent.transform.position;
        CurrentBehavior = new NPCPatrolState(PatrolPoints,PatrolReturn);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CurrentBehavior.StateUpdate(agent, transform);        
    }

    //Begin Chasing
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("Laika"))
        {
            excl.SetActive(true);
            sound.SetActive(true);
            if (CurrentBehavior is NPCPatrolState)
            {
                PatrolReturn = ((NPCPatrolState)CurrentBehavior).GetPatrolReturn();
            }
            CurrentBehavior = new NPCChasingState(other.gameObject);
        }
    }
    //Stop Chasing
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Equals("Laika"))
        {
            excl.SetActive(false);
            sound.SetActive(false);
            CurrentBehavior = new NPCPatrolState(PatrolPoints, PatrolReturn);
        }
    }



}
