﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Animator anim;
    bool firstHit;
    bool secondHit;
    bool hit1finished;
    bool hit2finished;
    float defaultHitSpeed;
    float curveValue;
    public float damage;

    public GameObject sword;

    private void Start()
    {
        anim = GetComponent<Animator>();
        defaultHitSpeed = anim.GetFloat("HitSpeed");
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && !isAttacking)
        {
            StartCoroutine(DoAttack1());
        }

        curveValue = anim.GetFloat("HitSpeedCurve");
    }

    float timeSinceStart;
    public bool isAttacking;

    IEnumerator DoAttack1()
    {
        hit1finished = false;
        hit1candamage = true;
        timeSinceStart = 0;
        canDoHit2 = false;
        bool hasHit = false;

        anim.SetTrigger("Attack1");

        while (!hit1finished)
        {
            isAttacking = true;

            CheckSwordCollider swordColl = sword.GetComponent<CheckSwordCollider>();
            if (swordColl.hasHitEnemy && !hasHit && swordColl.enemy != null && hit1candamage)
            {
                swordColl.enemy.GetComponent<Enemy>().TakeDamage(damage);
                hasHit = true;
            }

            if (Input.GetButtonDown("Fire1"))
            {
                if (canDoHit2)
                {
                    StartCoroutine(DoAttack2());
                    yield break;
                }
            }

            yield return false;
        }

        anim.ResetTrigger("Attack1");
        anim.ResetTrigger("Attack2");

        isAttacking = false;
    }

    IEnumerator DoAttack2()
    {
        canDoHit2 = false;
        anim.SetTrigger("Attack2");
        hit2candamage = true;
        bool hasHit = false;

        while (!hit2finished)
        {
            isAttacking = true;

            CheckSwordCollider swordColl = sword.GetComponent<CheckSwordCollider>();
            if (swordColl.hasHitEnemy && !hasHit && swordColl.enemy != null && hit2candamage)
            {
                swordColl.enemy.GetComponent<Enemy>().TakeDamage(damage);
                hasHit = true;
            }

            yield return false;
        }

        print("hit 2 finished");
        isAttacking = false;
    }

    public void Hit1Finished()
    {
        print("animation has finished");
        hit1finished = true;
    }

    public void Hit2Finished()
    {
        hit2finished = true;
    }

    bool hit1candamage;
    public void Hit1CanDamage()
    {
        hit1candamage = false;
    }

    bool hit2candamage;
    public void Hit2CanDamage()
    {
        hit2candamage = false;
    }

    bool canDoHit2;
    public void CanDoHit2()
    {
        canDoHit2 = true;
    }

    public void CanNotDoHit2()
    {
        canDoHit2 = false;
    }

    private void OnTriggerEnter(Collider other)
    {

    }
}
