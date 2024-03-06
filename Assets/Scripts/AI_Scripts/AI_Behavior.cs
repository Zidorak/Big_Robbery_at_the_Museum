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
    public Transform moveToGoal;

    // We create a currentState so we can access the first state at the start of the game, which will be "Explore".
    private State currentState;

    // We create a private Enum to determine what states are there for the AI to access.
    private enum State
    {
        LookForBatteries, // The AI walks around.
        PickUpBattery, // If the AI spots a door, it will walk to it and open it.
        OpenDoors, // If the AI spots an item, it will pick it up.
        InRoom, // If the AI picks up an item, or doesn't find an item inside a room, it will walk out of the room.
        OutOfRoom 
    }

    // Start is called before the first frame update
    void Start()
    {
        // We define the State "Explore" so the AI starts walking looking for doors to open or pick up items 
        currentState = State.LookForBatteries;

        // We get a reference to the NavMeshAgent.
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = moveToGoal.position;

        switch (currentState) // Since the currentState is "LookForKeys", we start the switch statement with it.
        {
            case State.LookForBatteries: // At the start of the game, the AI will look for keys to open doors.
                break;

            case State.PickUpBattery: // When a battery is spotted, the AI will walk to it and pick it up.
                break;

            case State.OpenDoors: // If the AI has a key, it will open a door that is in front of it.
                break;

            case State.InRoom: // Inside a room, the AI will look for items to pick up, or the statue (goal).
                break;

            case State.OutOfRoom: // If the AI has picked up all the items in a room or hasn't found anything, it will exit the room.
                break;
        }
    }

    public void switchState()
    {
        
    }

    /* Make a behaviour tree including all of those states from this script. 
       Then, apply the KeyScript and the TorchLight script so the AI can access those mechanics too.
       The AI will look for Batteries and keys, whatever it needs first, then it will look for doors,
       then it will look for the main goal, unless it has everything else, so then it will look for the goal
       straight away. */
    
}
