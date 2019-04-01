using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float damage;
    public GameObject sword;
    Animator swordAnim;
    Collider swordCollider;

    bool isActive;

    private void Start()
    {
        swordCollider = sword.GetComponent<Collider>();
        swordAnim = sword.transform.parent.GetComponent<Animator>();
    }

    private void Update()
    {
        AttackOnClick();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            if (isActive)
            {
                print("hit " + other.name);
                other.GetComponent<Enemy>().TakeDamage(damage);
                isActive = false;
            }
        }
    }

    Coroutine swordAttack;
    void AttackOnClick()
    {
        if (Input.GetButtonDown("Fire1") && animationFinished)
        {
            swordAttack = StartCoroutine(SetSwordActive());
            swordAnim.Play("Swordplaceholder");
        }
    }

    bool animationFinished = true;
    IEnumerator SetSwordActive()
    {
        animationFinished = false;
        isActive = true;
        yield return new WaitForSeconds(0.7f);
        animationFinished = true;
        isActive = false;
    }
}
