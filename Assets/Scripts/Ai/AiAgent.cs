using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiAgent : MonoBehaviour
{
    public AiStateMachine stateMachine;
    public AiStateId initialState;
    public NavMeshAgent navMeshAgent;
    public AiAgentConfig agentConfig;
    public Ragdoll ragdoll;
    public SkinnedMeshRenderer skinnedMeshRenderer;
    public UiHealthBar ui;

    // Start is called before the first frame update
    void Start()
    {
        ragdoll = GetComponent<Ragdoll>();
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        ui = GetComponent<UiHealthBar>();

        navMeshAgent = GetComponent<NavMeshAgent>();
        stateMachine = new AiStateMachine(this);
        stateMachine.RegisterState(new AiPlayerChaseState());
        stateMachine.RegisterState(new AiDeathState());
        stateMachine.ChangeState(initialState);
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.Update();
    }
}
