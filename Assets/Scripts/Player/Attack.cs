using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Animator anim;
    bool firstHit;
    bool secondHit;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isAttacking)
        {
            StartCoroutine(DoAttack());
        }
    }

    float timeSinceStart;
    bool isAttacking;

    IEnumerator DoAttack()
    {
        isAttacking = true;
        timeSinceStart = 0;

        print("attacking");
        anim.SetTrigger("Attack1");

        while (timeSinceStart < 0.6f)
        {
            timeSinceStart += Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (timeSinceStart > 0.1f && timeSinceStart < 0.6f)
                {
                    print("combo");
                    anim.SetTrigger("Attack2");
                }
            }

            yield return false;
        }

        anim.ResetTrigger("Attack1");
        anim.ResetTrigger("Attack2");
        isAttacking = false;
    }
}
