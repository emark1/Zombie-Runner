using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float playerHealth = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReduceHealth(float damage) {
        playerHealth -= damage;
        if (playerHealth <= 0) {
            Debug.Log("I'M DEAD OH NO");
        }
    }

}
