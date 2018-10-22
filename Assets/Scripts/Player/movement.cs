using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField]
    float speed;
    Rigidbody rb;
    Vector3 playerMovement;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        playerMovement = new Vector3(Input.GetAxisRaw("Vertical"), 0, -Input.GetAxisRaw("Horizontal"));
    }

    private void FixedUpdate()
    {
        //rb.MovePosition(rb.transform.position + movement * Time.deltaTime * speed);
        rb.velocity = playerMovement * Time.deltaTime * speed;
    }
}
