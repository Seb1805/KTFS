using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiBaseScript : MonoBehaviour
{
    public Transform playerPos;
    public float maxTime = 1.0f;
    public float maxDistance = 1.0f;


    NavMeshAgent agent;
    Animator animator;
    float timer = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Calc the path every second
        timer -= Time.deltaTime;
        if(timer < 0.0f)
        {
            //float distance = (playerPos.position - agent.destination).magnitude;
            float sqrDistance = (playerPos.position - agent.destination).sqrMagnitude;
            //if (distance > maxDistance)
            if (sqrDistance > maxDistance* maxDistance)
            {
                agent.destination = playerPos.position;
            }
            timer = maxTime;
        }

        //agent.destination = playerPos.position; > called every frame
        animator.SetFloat("Speed",agent.velocity.magnitude);
    }
}
