using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiIdleState : AiState
{
    public AiStateId GetId() {
        return AiStateId.Idle;
    }

    public void Enter(AiAgent agent) 
    {

    }

    public void Update(AiAgent agent) 
    {
        if (agent.FieldOfView.canSeePlayer == true)
        {
            agent.stateMachine.ChangeState(AiStateId.ChasePlayer);
        }
        else if (agent.FieldOfView.canSeePlayer == false)
        {
            return;
        }
    }

    public void Exit(AiAgent agent) 
    {

    }
}
