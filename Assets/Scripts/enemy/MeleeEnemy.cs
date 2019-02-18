using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeEnemy : Enemy
{
    float timeSinceLastAttack;
    bool isAttacking;
    int pathIndex;
    public float attackSpeed;
    bool move;
    private void Awake()
    {
        path = new NavMeshPath();
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        SpotPlayer();
        SetPath();
        if (move)
        {
            MoveTowardsPlayer();
        }
    }

    void MoveTowardsPlayer()
    {
        if (playerIsSpotted)
        {
            LookAtPlayer();
        }

        if (path.status == NavMeshPathStatus.PathComplete)
        {

            if (pathIndex >= path.corners.Length)
            {
                pathIndex = 0;
                path = new NavMeshPath();
            }

            if (Vector3.Distance(transform.position, player.transform.position) < 5f)
            {
                if (Vector3.Distance(transform.position, player.transform.position) < 1.5f)
                {
                    AttackPlayer();
                    return;
                }
                print("wlking towards palyer");
                transform.position += (player.transform.position - transform.position).normalized * speed * Time.deltaTime;
            }

            else
            {
                transform.position += (path.corners[pathIndex] - transform.position).normalized * Time.deltaTime * speed;
            }

            //transform.position += transform.forward * Time.deltaTime * speed;

            if (Vector3.Distance(transform.position, path.corners[pathIndex]) < 0.1f)
            {
                print("increasing index");
                if ((pathIndex + 1) < path.corners.Length)
                    pathIndex++;
                else
                {
                    print("resetting path");
                    path = new NavMeshPath();
                    pathIndex = 0;
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (path != null)
        {
            if (path.corners.Length > 0)
            {
                foreach (var item in path.corners)
                {
                    Debug.DrawLine(item, item + Vector3.up * 5, Color.red);
                }
            }
        }
    }

    NavMeshPath path;
    Vector3 closestWalkablePos;
    Vector3 positionToMoveTo;
    NavMeshHit hit;
    float timeSinceCalc;
    void SetPath()
    {
        timeSinceCalc += Time.deltaTime;

        if (timeSinceCalc >= 0f)
        {
            positionToMoveTo = playerLastSpotted;

            agent.CalculatePath(positionToMoveTo, path);
            if (path.status == NavMeshPathStatus.PathInvalid)
            {
                if (NavMesh.SamplePosition(positionToMoveTo, out hit, 100, LayerMask.NameToLayer("Walkable")))
                {
                    agent.CalculatePath(hit.position, path);
                }
            }

            print(path.corners.Length);
            move = true;
            timeSinceCalc = 0;
        }
    }

    public void LookAtPlayer()
    {
        print("looking at palyer");
        Quaternion lookRot = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, 0.06f);
    }

    void AttackPlayer()
    {
        print("hitting");
    }
}
