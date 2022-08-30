using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiBaseScript : MonoBehaviour
{
    public Transform playerPos;
    private NavMeshAgent agent;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = playerPos.position;
        animator.SetFloat("Speed",agent.velocity.magnitude);
    }
}
