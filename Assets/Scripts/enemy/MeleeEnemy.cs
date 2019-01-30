using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    float timeSinceLastAttack;
    bool isAttacking;
    public float attackSpeed;

    private void Update()
    {
        SpotPlayer();
        if (playerLastSpotted != Vector3.zero)
        {
            agent.SetDestination(playerLastSpotted);
        }

        print(agent.isStopped);

        MeleeAttack();
    }

    void MeleeAttack()
    {
        timeSinceLastAttack += Time.deltaTime;
        //print(timeSinceLastAttack);
        if (Vector3.Distance(transform.position, player.transform.position) < engagementDistance)
        {
            agent.isStopped = true;
            agent.velocity *= 0.95f;
            isAttacking = true;
            if (timeSinceLastAttack > attackSpeed)
            {
                timeSinceLastAttack = 0;
                //print("attacking");
            }
        }
        else
        {
            print("stopping attacking");
            isAttacking = false;
            agent.isStopped = false;
        }
    }
}
