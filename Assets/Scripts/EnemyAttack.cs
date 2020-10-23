using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float damage = 40f;

    PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = target.GetComponentInChildren<PlayerHealth>();
    }

    // Update is called once per frame
    public void AttackHitEvent() {
        if (!target) return;
        playerHealth.ReduceHealth(damage);
        Debug.Log("OOF");
    }
}
