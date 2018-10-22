using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    Transform player;               // Reference to the player's position.

    UnityEngine.AI.NavMeshAgent nav;               // Reference to the nav mesh agent.

    private playerHealth playerHp;
    private enemyHealth enemyHp;

    void Awake()
    {
        // Set up the references.
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        playerHp = GameObject.FindGameObjectWithTag("Player").GetComponent<playerHealth>();
        enemyHp = GameObject.FindGameObjectWithTag("Enemy").GetComponent<enemyHealth>();
    }


    void Update()
    {

        // if (Vector3.Distance(player.position, this.transform.position) < 20)
        //(enemyHp.currentHealth > 0 && playerHp.currentHealth > 0)
        // If the enemy and the player have health left...
        if (player != null)
        {
            if (Vector3.Distance(player.position, this.transform.position) < 20)
            {
                // ... set the destination of the nav mesh agent to the player.
                nav.SetDestination(player.position);

            }
            // Otherwise...
            else
            {
                // ... disable the nav mesh agent.
                nav.SetDestination(gameObject.transform.position);
            }
        }
    }

}
