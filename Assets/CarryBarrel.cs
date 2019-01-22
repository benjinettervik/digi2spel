using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryBarrel : MonoBehaviour
{
    GameObject currentBarrel;
    public GameObject barrelCarryPosition;
    PlayerMovement movement;

    bool isInteracting;

    private void Start()
    {
        movement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Barrel")
        {
            print("can interact");
            currentBarrel = collision.collider.gameObject;
            if (Input.GetButtonDown("Interact"))
            {
                isInteracting = true;
            }
        }
    }
}
