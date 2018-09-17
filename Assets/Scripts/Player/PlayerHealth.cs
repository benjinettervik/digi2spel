using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public float health;
    public int hitCount = 3;
    public float hitTime = 2;
    float curTime = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (health < 0f)
        {
            enemy.isPlayerAlive = false;
            Destroy(gameObject);
        }
        if (hitCount > 0)
        {
            curTime += Time.deltaTime;
        }
    }
}
        
