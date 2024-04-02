using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiChasePlayerState : AiState
{
    public AiStateId GetId() 
    {
        return AiStateId.ChasePlayer;
    }

    public void Enter(AiAgent agent) 
    {

    }

    public void Update(AiAgent agent) 
    {
        if (agent.FieldOfView.canSeePlayer == true)
        {
            agent.navMeshAgent.destination = agent.playerTransform.position;
        }
        if (agent.FieldOfView.canSeePlayer == false)
        {
            agent.stateMachine.ChangeState(AiStateId.Idle);
        }

        if (agent.FlashLightScript.lightOn == true && agent.FieldOfView.canSeePlayer == true)
        {
            agent.stateMachine.ChangeState(AiStateId.Stop);
        }
    }

    public void Exit(AiAgent agent) 
    {
        
    }
}
