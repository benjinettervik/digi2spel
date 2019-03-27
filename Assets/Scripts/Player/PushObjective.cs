using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushObjective : MonoBehaviour
{
    PlayerMovement movement;
    CharacterController cc;
    LayerMask pushableLayer;

    bool isInteracting;

    private void Start()
    {
        pushableLayer = LayerMask.NameToLayer("Pushable");
        cc = GetComponent<CharacterController>();
        movement = GetComponent<PlayerMovement>();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.moveDirection.y < -0.3)
        {
            return;
        }

        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        if (hit.collider.gameObject.layer == pushableLayer)
        {
            //putta hela objektet
            hit.transform.root.position += pushDir * Time.deltaTime;
        }
    }
}
