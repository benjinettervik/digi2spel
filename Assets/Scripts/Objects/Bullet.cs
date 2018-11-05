using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    Rigidbody rb;
    public float BulletSpeed;
    public float lifetime;
    private playerHealth player;
    public int damage;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerHealth>();
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(0, 0, BulletSpeed, ForceMode.Impulse);
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {
            player.Damage(damage);
            Destroy(gameObject);
        }
        if (collider.tag == "Wall")
        {
            Destroy(gameObject);
        }
        if (collider.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
