using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    float damage;

    private void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            print("hitting palyer");
            GameObject player = other.gameObject;

            player.GetComponent<PlayerHealth>().TakeDamage(damage);

            Destroy(gameObject);
        }

        if (other.tag == "Wall")
        {
            Destroy(gameObject);
        }

    }
}
