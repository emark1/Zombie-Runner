using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 10f;
    [SerializeField] float turnSpeed = 5f;
    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    public bool isProvoked = false;


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
        FaceTarget();
        if (distanceToTarget >= navMeshAgent.stoppingDistance) {
            ChaseTarget();
        }
        
        if (distanceToTarget <= navMeshAgent.stoppingDistance) {
            AttackTarget();
        }
    }

    private void ChaseTarget() {
        GetComponentInChildren<Animator>().SetBool("attack", false);
        GetComponentInChildren<Animator>().SetTrigger("move");

        navMeshAgent.SetDestination(target.position);
    }

    private void AttackTarget() {
        GetComponentInChildren<Animator>().SetBool("attack", true);
        Debug.Log("ATTACK ATTACK");
    }

    private void FaceTarget() {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }
}
