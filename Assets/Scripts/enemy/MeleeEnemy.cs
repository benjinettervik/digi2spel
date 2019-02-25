using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeEnemy : Enemy
{
    NavMeshPath path;
    Vector3 closestWalkablePos;
    Vector3 positionToMoveTo;
    NavMeshHit hit;
    float timeSinceCalc;
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

    private void FixedUpdate()
    {
        SpotPlayer();
    }

    private void Update()
    {
        SetWalkingPosition();
        if (Vector3.Distance(positionToMoveTo, transform.position) > 1)
        {
            SetPath();
        }

        if (move)
        {
            MoveTowardsPlayer();
        }
    }

    void MoveTowardsPlayer()
    {
        //kolla på spelaren ifall den är synlig
        if (playerIsSpotted)
        {
            LookAtPlayer();
        }

        //om pathen har blivit klarkalkylerad så går fienden
        if (path.status == NavMeshPathStatus.PathComplete)
        {
            if (path.corners.Length > 1)
            {
                Vector3 moveDir = (path.corners[1] - transform.position).normalized;
                moveDir.y = 0;
                transform.position += moveDir * Time.deltaTime * speed;
                Debug.DrawLine(transform.position + Vector3.up, (transform.position + Vector3.up) + moveDir);
            }

            /*if (Vector3.Distance(transform.position, player.transform.position) < 5f)
            {
                if (Vector3.Distance(transform.position, player.transform.position) < 1.5f)
                {
                    AttackPlayer();
                    return;
                }
                Vector3 moveDir = (player.transform.position - transform.position).normalized * speed * Time.deltaTime;
                moveDir.y = 0;
                transform.position += moveDir;
            }
            */
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
        Debug.DrawLine(playerLastSpotted, playerLastSpotted + Vector3.up * 5, Color.red);
    }
    void SetPath()
    {
        Debug.ClearDeveloperConsole();
        timeSinceCalc += Time.deltaTime;

        if (timeSinceCalc >= 0f)
        {
            agent.CalculatePath(positionToMoveTo, path);
            if (path.status == NavMeshPathStatus.PathInvalid)
            {
                if (NavMesh.SamplePosition(positionToMoveTo, out hit, 100, LayerMask.NameToLayer("Walkable")))
                {
                    agent.CalculatePath(hit.position, path);
                }
            }

            print("length " + path.corners.Length);
            move = true;
            timeSinceCalc = 0;
        }
    }

    public void LookAtPlayer()
    {
        Quaternion lookRot = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, 0.06f);
    }

    void AttackPlayer()
    {
        print("hitting");
    }

    void SetWalkingPosition()
    {
        if (moveToDesigPos)
        {
            positionToMoveTo = desigPos.position;
        }
        else
        {
            positionToMoveTo = playerLastSpotted;
        }
    }
}
