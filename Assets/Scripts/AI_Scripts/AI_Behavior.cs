using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.AI;

public class AI_Behavior : MonoBehaviour
{
    // aiSpeed has the same value as the player character's speed. 
    public float aiSpeed = 4.0f;

    // We create a variable so we can get the NavMeshAgent.
    public NavMeshAgent agent;

    // We create a currentState so we can access the first state at the start of the game, which will be "Explore".
    private State currentState;

    public Transform[] waypoints;

    public int currentWaypoint = 0;

    public FlashLight flashLightScript;

    public float range;

    public Transform centrePoint;


    // We create a private Enum to determine what states are there for the AI to access.
    private enum State
    {
        RandomPatrol, // The AI will patrol 
        StealBatteries, // The AI will look for batteries if the intensity is less than 0.5f.
    }

    // Start is called before the first frame update
    void Start()
    {
        // We get a reference to the NavMeshAgent.
        agent = GetComponent<NavMeshAgent>();
        
        // Reference to the Player's FlashLight.
        GetComponent<FlashLight>();

        // We define the State to be "RandomPatrol" so the AI starts walking around the level. 
       // currentWaypoint = 0;
        currentState = State.RandomPatrol;
    }

    // Update is called once per frame
    void Update()
    {
        SwitchState();

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            currentState = State.StealBatteries;
        }
    }

    public void SwitchState()
    {
        switch (currentState) // Since the currentState is "RandomPatrol", we start the switch statement with it.
        {
            case State.RandomPatrol:

                if (flashLightScript.currentBatteries > 0)
                {
                    if (agent.remainingDistance <= agent.stoppingDistance) //done with path
                    {
                        Vector3 point;
                        if (RandomPoint(centrePoint.position, range, out point)) //pass in our centre point and radius of area
                        {
                            Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); //so you can see with gizmos
                            agent.SetDestination(point);
                        }
                    }
                }

                if (flashLightScript.currentBatteries == 0)
                {
                    currentState = State.StealBatteries;
                }

            break;
        }

        switch (currentState)
        {
            case State.StealBatteries:

                if (waypoints.Length == 0)
                {
                    return;
                }

                currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
                agent.SetDestination(waypoints[currentWaypoint].transform.position);


                if (flashLightScript.currentBatteries > 0)
                {
                    currentState = State.RandomPatrol;
                }

            break;
        }
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {

        Vector3 randomPoint = center + Random.insideUnitSphere * range; //random point in a sphere 
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        {
            //the 1.0f is the max distance from the random point to a point on the navmesh, might want to increase if range is big
            //or add a for loop like in the documentation
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }

    /* Make a behaviour tree including all of those states from this script. 
       Then, apply the KeyScript and the TorchLight script so the AI can access those mechanics too.
       The AI will look for Batteries and keys, whatever it needs first, then it will look for doors,
       then it will look for the main goal, unless it has everything else, so then it will look for the goal
       straight away. */

}
