using UnityEngine;
using UnityEngine.AI;

public class EnemyPathing : MonoBehaviour
{
    public Transform playerBase;
    public NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        agent.SetDestination(playerBase.position);
    }
}
