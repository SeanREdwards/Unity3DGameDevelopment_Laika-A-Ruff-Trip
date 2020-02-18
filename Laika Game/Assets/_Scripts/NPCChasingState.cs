using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCChasingState : INPCState
{
    private GameObject Player;
    public NPCChasingState(GameObject player)
    {
        Player = player;
    }

    public void StateUpdate(NavMeshAgent agent, Transform NPCPosition)
    {
        agent.destination = Player.transform.position;
        Vector3 targetDirection = Player.transform.position - NPCPosition.parent.transform.position;
        float singleStep = 2.0f * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(NPCPosition.parent.transform.forward, targetDirection, singleStep, 0.0f);
        NPCPosition.parent.transform.rotation = Quaternion.LookRotation(newDirection);
    }
}
