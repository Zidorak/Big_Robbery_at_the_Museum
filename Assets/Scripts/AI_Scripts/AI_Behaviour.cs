using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class AI_Behaviour : MonoBehaviour
{
    public State currentState;

    public NavMeshAgent agent;

    public GameObject keyOB;

    public GameObject RedKeyOB;
    public GameObject BlueKeyOB;
    public GameObject YellowKeyOB;
    public GameObject GreenKeyOB;

    public enum State
    {
        FindItems,
        OpenDoor,
        OpenGoalDoor
    }
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentState = State.FindItems;
    }

    // Update is called once per frame
    void Update()
    {
        SwitchState();
    }

    public void SwitchState()
    {
        switch (currentState)
        {
            case State.FindItems:
                FindItems();
                break;
        
            case State.OpenDoor:
                OpenDoor();
                break;

            case State.OpenGoalDoor:
                OpenGoalDoor();
                break;
        }
    }

    public void FindItems()
    {
        if (currentState == State.FindItems)
        {
            GameObject.FindWithTag("Key");
            //GameObject.FindWithTag("RedKey");
            //GameObject.FindWithTag("BlueKey");
            //GameObject.FindWithTag("YellowKey");
            //GameObject.FindWithTag("GreenKey");
            //GameObject.FindWithTag("Battery");
        }
        //if (currentState == State.FindItems && RedKeyOB.activeInHierarchy && 
        //    BlueKeyOB.activeInHierarchy && YellowKeyOB.activeInHierarchy && GreenKeyOB.activeInHierarchy)
        //{
        //    currentState = State.OpenGoalDoor;
        //}
        //if (currentState == State.FindItems && keyOB.activeInHierarchy)
        //{
        //    currentState = State.OpenDoor;
        //}
        //else
        //{
        //    currentState = State.FindItems;
        //}
    }

    public void OpenDoor()
    {
        if (currentState == State.OpenDoor) 
        {
            
        }
    }

    public void OpenGoalDoor()
    {

    }
}
