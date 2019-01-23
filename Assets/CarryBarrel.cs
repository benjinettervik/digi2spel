using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryBarrel : MonoBehaviour
{
    GameObject currentBarrel;
    public GameObject barrelCarryPosition;
    PlayerMovement movement;
    CharacterController cc;

    bool isInteracting;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
        movement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (isInteracting)
        {
            currentBarrel.transform.position = barrelCarryPosition.transform.position;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.moveDirection.y < -0.3)
        {
            return;
        }

        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        if (hit.collider.tag == "Barrel")
        {
            hit.transform.position += pushDir * Time.deltaTime;
        }
    }
}
