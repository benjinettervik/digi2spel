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
    private void Awake()
    {
        path = new NavMeshPath();
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");

        SetPath();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SetPath();
        }

        SpotPlayer();
        MoveTowardsPlayer();
    }

    void MoveTowardsPlayer()
    {
        Debug.Log(path.status);
        if (agent.hasPath && path.status == NavMeshPathStatus.PathComplete)
        {
            transform.position += (path.corners[pathIndex] - transform.position).normalized * Time.deltaTime * speed;
            if (Vector3.Distance(transform.position, path.corners[pathIndex]) < 0.1f)
            {
                print("increasing index");
                if ((pathIndex + 1) < path.corners.Length)
                    pathIndex++;
                else
                {
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
    void SetPath()
    {
        agent.CalculatePath(player.transform.position, path);
        if (path.status == NavMeshPathStatus.PathInvalid)
        {

        }
    }
}
