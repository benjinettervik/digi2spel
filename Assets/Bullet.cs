using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    Rigidbody rb;
    public float BulletSpeed;
    public float lifetime;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(0, 0, BulletSpeed, ForceMode.Impulse);
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {
        Destroy(gameObject);
        }
        if (collider.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
