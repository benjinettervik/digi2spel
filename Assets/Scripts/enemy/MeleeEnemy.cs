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
    public float rangeUntilEngage;
    public float heightOverGround;
    bool move;

    public bool moveTest;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        path = new NavMeshPath();
    }

    private void Start()
    {
        Time.timeScale = 1;
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        SpotPlayer();
    }

    private void Update()
    {
        print(health);
        SetWalkingPosition();
        AttackPlayer();

        if (Vector3.Distance(positionToMoveTo, transform.position) > 1)
        {
            SetPath();
        }

        if (!moveTest)
        {
            MoveTowardsPlayer();
        }

        SetAnimation();
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
                isMoving = true;
                Vector3 moveDir = (path.corners[1] - transform.position).normalized;
                moveDir.y = 0;
                if (Vector3.Distance(transform.position, player.transform.position) > rangeUntilEngage)
                {
                    transform.position += moveDir * Time.deltaTime * speed;
                }
                else
                {
                    isMoving = false;
                }
                Debug.DrawLine(transform.position + Vector3.up, (transform.position + Vector3.up) + moveDir * 5);
            }

            else
            {
                isMoving = false;
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

        Debug.DrawLine(playerLastSpotted, playerLastSpotted + Vector3.up * 5, Color.red);
    }

    void SetPath()
    {
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
        timeSinceLastAttack += Time.deltaTime;
        if (Vector3.Distance(transform.position, player.transform.position) < 2f)
        {
            if (timeSinceLastAttack > 3f)
            {
                anim.SetTrigger("AttackPlayer");
                print("attacking");
                timeSinceLastAttack = 0;
            }
            else
            {
                anim.ResetTrigger("AttackPlayer");
            }
        }
        else
        {
            anim.ResetTrigger("AttackPlayer");
        }
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

    void SetAnimation()
    {
        if (isMoving)
        {
            anim.SetBool("IsMoving", true);
        }
        else
        {
            anim.SetBool("IsMoving", false);
        }
    }
}
