using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour {

    public int currentHealth;
    public int maxhealth = 5;
    

    // Use this for initialization
    void Start()
    {
        currentHealth = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth > maxhealth)
        {
            currentHealth = maxhealth;
        }
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    public void Damage(int dmg)
    {
        currentHealth -= dmg;
    }
}
