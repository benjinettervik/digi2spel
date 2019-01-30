using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [HideInInspector]
    public NavMeshAgent agent;
    public float health;
    public float damage;
    public float sightRange;
    public float engagementDistance;
    [HideInInspector]
    public bool playerIsSpotted;
    [HideInInspector]
    public Vector3 playerLastSpotted = Vector3.zero;

    [HideInInspector]
    public GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            //die
        }
    }

    public void SpotPlayer()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < sightRange)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, player.transform.position - transform.position, out hit, sightRange))
            {
                if (hit.collider.tag == "Player")
                {
                    playerLastSpotted = hit.collider.transform.position;
                    print("player is spotted");
                }
            }
        }
    }
}
