using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiChasePlayerState : AiState
{
    float timer = 0.0f;

    public AiStateId GetId() 
    {
        return AiStateId.ChasePlayer;
    }

    public void Enter(AiAgent agent) 
    {

    }

    public void Update(AiAgent agent) 
    {
        if (!agent.enabled) 
        {
            return;
        }

        timer -= Time.deltaTime;
        if (!agent.navMeshAgent.hasPath) 
        {
            agent.navMeshAgent.destination = agent.playerTransform.position;
        }

        if (timer < 0.0f) 
        {
            Vector3 direction = (agent.playerTransform.position - agent.navMeshAgent.destination);
            direction.y = 0;
            if (direction.sqrMagnitude > agent.config.maxDistance * agent.config.maxDistance && agent.FieldOfView.canSeePlayer == true) 
            {
                if (agent.navMeshAgent.pathStatus != NavMeshPathStatus.PathPartial) 
                {
                    agent.navMeshAgent.destination = agent.playerTransform.position;
                }
            }
            timer = agent.config.maxTime;
        }
        
        Vector3 playerDirection = agent.playerTransform.position - agent.transform.position;
        if (playerDirection.magnitude > agent.config.maxSightDistance)
        {
            agent.stateMachine.ChangeState(AiStateId.Idle);
        }


        if (agent.FlashLightScript.lightOn)
        {
            agent.navMeshAgent.enabled = false;
        }

        if (agent.FlashLightScript.lightOn == false)
        {
            agent.navMeshAgent.enabled = true;
            agent.stateMachine.ChangeState(AiStateId.Idle);
        }
    }

    public void Exit(AiAgent agent) 
    {
        
    }
}
