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

    public FlashLight flashLightScript;

    public KeyScript keyScript;


    // We create a private Enum to determine what states are there for the AI to access.
    private enum State
    {
        LookForStatue,
        LookForBatteries, // The AI will look for batteries if the intensity is less than 0.5f.
        PickUpItem, // If the AI spots a door, it will walk to it and open it.
        OpenDoors, // If the AI spots an item, it will pick it up.
    }

    // Start is called before the first frame update
    void Start()
    {
        // We define the State "Explore" so the AI starts walking looking for doors to open or pick up items 
        currentState = State.LookForStatue;

        // We get a reference to the NavMeshAgent.
        agent = GetComponent<NavMeshAgent>();
        
        GetComponent<FlashLight>();
        GetComponent<KeyScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //agent.destination = moveToGoal.position;

        SwitchState();
    }

    public void SwitchState()
    {
        switch (currentState) // Since the currentState is "LookForKeys", we start the switch statement with it.
        {
            case State.LookForStatue:

                if (flashLightScript.flashLight.intensity > 0.5f)
                {
                    // Look for keys to so the AI can access other rooms.
                }

                if (flashLightScript.flashLight.intensity < 0.5f)
                {
                    currentState = State.LookForBatteries;
                }

                break;

            case State.LookForBatteries: // At the start of the game, the AI will look for keys to open doors.

                if (flashLightScript.flashLight.intensity < 0.5f)
                {
                    // Look for batteries.
                }

                if (flashLightScript.flashLight.intensity > 0.5f)
                {
                    currentState = State.PickUpItem; // Now the AI will look for items.
                }

                break;

            case State.PickUpItem: // When a battery is spotted, the AI will walk to it and pick it up.

                // If the AI has spotted any items nearby, it will walk to it and pick it up.

                if (flashLightScript.flashLight.intensity < 0.5f)
                {
                    // Look for batteries.
                    currentState = State.LookForBatteries;
                }

                break;

            case State.OpenDoors: // If the AI has a key, it will open a door that is in front of it.

                if (keyScript.keyOB.activeInHierarchy)
                {
                    // Open a locked door. HOW????
                }

                if (flashLightScript.flashLight.intensity < 0.5f)
                {
                    currentState = State.LookForBatteries;
                }

                break;
        }
    }

    /* Make a behaviour tree including all of those states from this script. 
       Then, apply the KeyScript and the TorchLight script so the AI can access those mechanics too.
       The AI will look for Batteries and keys, whatever it needs first, then it will look for doors,
       then it will look for the main goal, unless it has everything else, so then it will look for the goal
       straight away. */
    
}
