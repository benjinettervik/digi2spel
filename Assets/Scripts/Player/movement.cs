using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    float speed;
    Rigidbody rb;
    Vector3 movement;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        movement = new Vector3(Input.GetAxisRaw("Vertical"), 0, -Input.GetAxisRaw("Horizontal"));
    }

    private void FixedUpdate()
    {
        //rb.MovePosition(rb.transform.position + movement * Time.deltaTime * speed);
        rb.velocity = movement * Time.deltaTime * speed;
    }
}
