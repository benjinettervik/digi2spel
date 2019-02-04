using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float currentHealth;
    public int maxhealth = 5;

    void Start()
    {
        currentHealth = maxhealth;
    }

    public void Damage(float dmg)
    {
        currentHealth -= dmg;

        if (currentHealth <= 0)
        {
            //die
            print("dead");
        }
    }
}
