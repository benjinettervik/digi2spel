using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSwordCollider : MonoBehaviour
{
    public bool hasHitEnemy;
    public GameObject enemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            hasHitEnemy = true;
            enemy = other.gameObject;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            hasHitEnemy = true;
            enemy = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            hasHitEnemy = false;
            enemy = null;
        }
    }
}
