using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    Transform player;               // Reference to the player's position.
           
    UnityEngine.AI.NavMeshAgent nav;               // Reference to the nav mesh agent.


    void Awake()
    {
        // Set up the references.
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }


    void Update()
    {
        // If the enemy and the player have health left...
        if (Vector3.Distance(player.position, this.transform.position) < 20)
        {
            // ... set the destination of the nav mesh agent to the player.
            nav.SetDestination(player.position);
        }
        // Otherwise...
        else
        {
            // ... disable the nav mesh agent.
            nav.enabled = false;
        }
    }
}
