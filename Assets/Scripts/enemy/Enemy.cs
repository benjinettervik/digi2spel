using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [HideInInspector]
    public NavMeshAgent agent;
    public float speed;
    public float health;
    public float damage;
    public float sightRange;
    public float engagementDistance;
    public bool moveToDesigPos = true;
    float timeSinceLastSpotted;
    [HideInInspector]
    public bool playerIsSpotted;
    [HideInInspector]
    public Vector3 playerLastSpotted = Vector3.zero;
    public Transform desigPos;

    public GameObject player;

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
        timeSinceLastSpotted += Time.deltaTime;
        if (Vector3.Distance(transform.position, player.transform.position) < sightRange)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, player.transform.position - transform.position, out hit, sightRange))
            {
                if (hit.collider.tag == "Player")
                {
                    playerLastSpotted = hit.collider.transform.position;
                    playerIsSpotted = true;
                    moveToDesigPos = false;
                    //detta är för att förhindra att den hackar mycket när den ska kolla på spelaren, för av någon anledning trffar inte rayen spelaren typ varannan frame  
                    timeSinceLastSpotted = 0;
                }
                else if(timeSinceLastSpotted > 0.5)
                {
                    playerIsSpotted = false;
                }
            }
        }
    }
}
