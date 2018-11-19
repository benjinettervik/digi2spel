using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    Transform player;               // Reference to the player's position.

    UnityEngine.AI.NavMeshAgent nav;               // Reference to the nav mesh agent.

    private playerHealth playerHp;
    private enemyHealth enemyHp;
    public int Range = 20;


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

        
        if (player != null)
        {
            if (Vector3.Distance(player.position, this.transform.position) < 20)
            {
                // ... set the destination of the nav mesh agent to the player.
                nav.SetDestination(player.position);
                if (Vector3.Distance(player.position, this.transform.position) < 10)
                {
                    nav.SetDestination(gameObject.transform.position);
                }
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
