using UnityEngine;
using UnityEngine.AI;

public class EnemyWalk : MonoBehaviour
{
    public Transform Playerpos;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        if (Playerpos)
        {
            transform.LookAt(Playerpos);
        }
        agent.destination = Playerpos.position;

    }
}