using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public interface INPCState
{
    void StateUpdate(NavMeshAgent agent, Transform NPCPosition);
}
