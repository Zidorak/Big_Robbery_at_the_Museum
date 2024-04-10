using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class AiAgent : MonoBehaviour
{
    public AiStateId initialState;
    public AiStateMachine stateMachine;
    public NavMeshAgent navMeshAgent;
    public Transform playerTransform;
    public FlashLight FlashLightScript;
    public FieldOfView FieldOfView;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<FieldOfView>();
        GetComponent<FlashLight>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        stateMachine = new AiStateMachine(this);
        stateMachine.RegisterState(new AiChasePlayerState());
        stateMachine.RegisterState(new AiIdleState());
        stateMachine.RegisterState(new AiStopState());
        stateMachine.RegisterState(new AiKillPlayerState());
        stateMachine.ChangeState(initialState);
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.Update();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.Destroy(other.transform.gameObject);
            SceneManager.LoadScene(3);
        }
    }
}
