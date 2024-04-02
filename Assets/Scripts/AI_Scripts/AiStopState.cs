using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiStopState : AiState
{
    public AiStateId GetId()
    {
        return AiStateId.Stop;
    }
 
    public void Enter(AiAgent agent)
    {
        
    }

    public void Update(AiAgent agent)
    {
        if (agent.FlashLightScript.lightOn == true && agent.navMeshAgent.enabled == true)
        {
            agent.navMeshAgent.enabled = false;
            agent.FieldOfView.canSeePlayer = false;
        }

        if (agent.FlashLightScript.lightOn == false && agent.navMeshAgent.enabled == false)
        {
            agent.navMeshAgent.enabled = true;
            agent.stateMachine.ChangeState(AiStateId.ChasePlayer);
            //agent.FieldOfView.canSeePlayer = true;
        }
    }
    public void Exit(AiAgent agent)
    {

    }
}
