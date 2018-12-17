﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Knockback : MonoBehaviour
{

    public NavMeshAgent navAgent;
    bool knockBack;
    Vector3 direction;

    void Start()
    {
        knockBack = false;
    }

    void FixedUpdate()
    {
        if (knockBack)
        {
            navAgent.velocity = direction * 8;//Knocks the enemy back when appropriate
        }
    }

    IEnumerator KnockBack()
    {
        knockBack = true;
        navAgent.speed = 10;
        navAgent.angularSpeed = 0;//Keeps the enemy facing forwad rther than spinning
        navAgent.acceleration = 20;

        yield return new WaitForSeconds(0.2f); //Only knock the enemy back for a short time    

        //Reset to default values
        knockBack = false;
        navAgent.speed = 4;
        navAgent.angularSpeed = 180;
        navAgent.acceleration = 10;
    }

    private void OnTriggerEnter(Collider collision)
    {
        Vector3 delta = transform.position - collision.transform.position;
        delta.Normalize();

        direction = delta; //Always knocks ememy in the direction the main character is facing
        print(collision.gameObject.tag);

        if (collision.gameObject.tag == ("Trigger"))
        {
            StartCoroutine(KnockBack());
        }
    }
}