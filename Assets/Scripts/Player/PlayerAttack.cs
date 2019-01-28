using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {
    
    private enemyHealth enemy;
    public int damage;
    private bool attacking = false;
    private float attackTimer = 0;
    private float attackCD = 0.3f;

    public Collider attackTrigger;
	// Use this for initialization
	void Start () {
       
    }
	
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemy = collision.gameObject.GetComponent<enemyHealth>();
            enemy.Damage(damage);
        }
    }  
	// Update is called once per frame
    void Awake()
    {
        attackTrigger.enabled = false;
    }
	void Update () {
        if (Input.GetKeyDown("k") && !attacking)
        {
            attacking = true;
            attackTimer = attackCD;

            attackTrigger.enabled = true;
        }
        if (attacking)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                attackTrigger.enabled = false;
            }
        }
    }
}
