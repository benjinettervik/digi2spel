﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    private PlayerHealth player;
    public int currentHealth;
    public int maxHealth = 1;
    public int damage;
    // Use this for initialization
    void Start()
    {
        currentHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }


    // Update is called once per frame
    void Update()
    {
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag==("Player"))
        {
            player.TakeDamage(damage);
        }
    }




    public void Damage(int dmg)
    {
        

        currentHealth -= dmg;

    }
}
