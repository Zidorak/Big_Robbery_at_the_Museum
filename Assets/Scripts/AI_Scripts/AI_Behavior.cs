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
        Explore, // The AI walks around.
        OpenDoor, // If the AI spots a door, it will walk to it and open it.
        PickUp, // If the AI spots an item, it will pick it up.
        Return // If the AI picks up an item, or doesn't find an item inside a room, it will walk out of the room.
    }

    // Start is called before the first frame update
    void Start()
    {
        // We define the State "Explore" so the AI starts walking looking for doors to open or pick up items 
        currentState = State.Explore;

        // We get a reference to the NavMeshAgent.
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = moveToGoal.position;

        switch (currentState) // Since the currentState is "Explore", we start the switch statement with it.
        {
            case State.Explore: // At the start of the game, the AI will explore (walk), and look for doors to open.
                break;

            case State.OpenDoor: // When a door is spotted, the AI will walk to it, open it and enter the room.
                break;

            case State.PickUp: // Inside the rooms, the AI will look for items to pick up, if there are none, it will walk out.
                break;

            case State.Return: // AI will walk out of a room and return to "Explore" state.
                break;
        }
    }

    public void switchState()
    {
        if (currentState == State.Explore)
        {
            currentState = State.OpenDoor;
        }
        else if (currentState == State.OpenDoor)
        {
            currentState = State.PickUp;
        }
        else
        {
            currentState = State.Explore;
        }
    }
}
