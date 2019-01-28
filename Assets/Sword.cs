using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public bool isActive;
    Animator animationController;
    private enemyHealth enemy;
    public int damage;

    private void Awake()
    {
        animationController = GetComponent<Animator>();
    }

    private void Update()
    {
        Attack();
        print(isActive);
    }

    void Attack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(SetSwordActive());
            animationController.Play("Swordplaceholder");
        }
    }


    IEnumerator SetSwordActive()
    {
        yield return new WaitForSeconds(0.5f);
        isActive = true;
        yield return new WaitForSeconds(0.5f);
        isActive = false;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == ("Enemy"))
        {
            enemy = collision.gameObject.GetComponent<enemyHealth>();
            enemy.Damage(2);
        }
    }
}
