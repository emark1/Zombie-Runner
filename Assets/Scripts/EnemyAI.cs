using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 10f;
    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;


    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = new Color(1, 1, 0, 0.75F);
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (isProvoked) {
            EngageTarget();
        } else if (distanceToTarget <= chaseRange) {
            isProvoked = true;
        }
        
    }

    private void EngageTarget() {
        if (distanceToTarget >= navMeshAgent.stoppingDistance) {
            ChaseTarget();
        }
        
        if (distanceToTarget <= navMeshAgent.stoppingDistance) {
            AttackTarget();
        }
    }

    private void ChaseTarget() {
        navMeshAgent.SetDestination(target.position);
    }

    private void AttackTarget() {
        Debug.Log("ATTACK ATTACK");
    }
}
