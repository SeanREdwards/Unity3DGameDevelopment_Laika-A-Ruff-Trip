using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCPatrolState : INPCState
{
    private List<GameObject> PatrolPoints;
    private GameObject NextPatrolPoint;
    private int PatrolPointIndex;
    public NPCPatrolState(List<GameObject> patrolPoints)
    {
        PatrolPoints = patrolPoints;
        NextPatrolPoint = PatrolPoints[0];
        PatrolPointIndex = 0;
    }

    public void StateUpdate(NavMeshAgent agent, Transform NPCPosition)
    {
        agent.destination = NextPatrolPoint.transform.position;
        Vector3 targetDirection = NextPatrolPoint.transform.position - NPCPosition.position;
        targetDirection.y = 0;
        float singleStep = 2.0f * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(NPCPosition.forward, targetDirection, singleStep, 0.0f);
        NPCPosition.rotation = Quaternion.LookRotation(newDirection);

        if(targetDirection.magnitude < 1)
        {
            PatrolPointIndex = (PatrolPointIndex + 1) % PatrolPoints.Capacity;
            NextPatrolPoint = PatrolPoints[PatrolPointIndex];
        }
    }
}
