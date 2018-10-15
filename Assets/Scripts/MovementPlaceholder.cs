using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlaceholder : MonoBehaviour
{
    [SerializeField]
    float speed;
    Vector3 movement;

    private void Update()
    {
       movement = (Input.GetAxisRaw("Horizontal") * transform.forward + Input.GetAxisRaw("Vertical") * transform.right) * Time.deltaTime * speed;
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity = movement;
    }
}
