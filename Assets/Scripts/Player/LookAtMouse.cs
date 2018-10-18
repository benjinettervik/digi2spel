using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    LayerMask layerMask;
    public float rayCamLength;

    private void Awake()
    {
        layerMask = LayerMask.GetMask("Floor");
    }

    private void FixedUpdate()
    {
        RotateToRayPos();
    }

    void RotateToRayPos()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit, rayCamLength, layerMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            GetComponent<Rigidbody>().MoveRotation(newRotation);

            print("hitting");
        }
    }
}
