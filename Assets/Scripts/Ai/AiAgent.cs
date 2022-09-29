using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiAgent : MonoBehaviour
{
    public AiAgentConfig agentConfig;
    public AiStateId initialState;

    public AiStateMachine stateMachine;
    public NavMeshAgent navMeshAgent;
    public Ragdoll ragdoll;
    public SkinnedMeshRenderer skinnedMeshRenderer;
    public UiHealthBar ui;
    public Transform playerTransform;
    public AiWeapons weapons;

    // Start is called before the first frame update
    void Start()
    {
        ragdoll = GetComponent<Ragdoll>();
        skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        ui = GetComponentInChildren<UiHealthBar>();

        navMeshAgent = GetComponent<NavMeshAgent>();
        weapons = GetComponent<AiWeapons>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        stateMachine = new AiStateMachine(this);
        stateMachine.RegisterState(new AiPlayerChaseState());
        stateMachine.RegisterState(new AiDeathState());
        stateMachine.RegisterState(new AiIdleState());
        stateMachine.RegisterState(new AiFindWeaponState());
        stateMachine.ChangeState(initialState);
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.Update();
    }
}
