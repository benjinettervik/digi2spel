using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RangedEnemy : Enemy
{
    public GameObject projectileObj;
    public GameObject barrelPos;

    NavMeshPath path;
    Vector3 closestWalkablePos;
    Vector3 positionToMoveTo;
    Vector3 moveDir;
    Vector3 lastPath;
    NavMeshHit hit;
    float timeSinceCalc;
    float timeSinceLastAttack;
    bool isAttacking;
    int pathIndex;
    public float attackSpeed;
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
        SetupHealthBar();

        //desigPos.position = new Vector3(desigPos.position.x, transform.position.y, desigPos.position.z);

        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");

        anim.speed = UnityEngine.Random.Range(0.8f, 1.1f);
    }

    public override void Update()
    {
        base.Update();

        SetWalkingPosition();
        AttackPlayer();

        if (Vector3.Distance(positionToMoveTo, transform.position) > 1)
        {
            SetPath();
        }

        if (!dontMove)
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

                if (path.corners[1] != lastPath)
                    moveDir = (path.corners[1] - transform.position).normalized;

                lastPath = path.corners[1];

                Debug.DrawLine(transform.position, transform.position + moveDir);

                moveDir.y = 0;

                if (Vector3.Distance(transform.position, player.transform.position) > engagementDistance)
                    transform.position += moveDir * Time.deltaTime * speed;

                else
                    isMoving = false;
            }

            else
                isMoving = false;

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
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, 5f * Time.deltaTime);
    }

    void AttackPlayer()
    {
        timeSinceLastAttack += Time.deltaTime;
        if (Vector3.Distance(transform.position, player.transform.position) < (engagementDistance + 1))
        {
            if (timeSinceLastAttack > 3f)
            {
                //anim.SetTrigger("AttackPlayer");
                var projectile = Instantiate(projectileObj, barrelPos.transform.position, transform.rotation);
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
        if (dontMove)
        {
            //positionToMoveTo = desigPos.position;
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
