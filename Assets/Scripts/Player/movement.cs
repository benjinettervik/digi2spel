using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    float accelerationSpeed;
    Rigidbody rb;
    Vector3 playerMovement;

    CharacterController cc;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        cc = GetComponent<CharacterController>();
    }

    float xMovement;
    float yMovement;
    private void Update()
    {
        xMovement += Input.GetAxisRaw("Horizontal") * Time.deltaTime * accelerationSpeed;
        yMovement += Input.GetAxisRaw("Vertical") * Time.deltaTime * accelerationSpeed;

        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            xMovement = Mathf.Lerp(xMovement, 0, 1f);
        }

        if (Input.GetAxisRaw("Vertical") == 0)
        {
            yMovement = Mathf.Lerp(yMovement, 0, 1f);
        }

        xMovement = Mathf.Clamp(xMovement, -1, 1);
        yMovement = Mathf.Clamp(yMovement, -1, 1);

        playerMovement = new Vector3(yMovement, 0, -xMovement);
        //cc.Move(playerMovement * Time.deltaTime * speed);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.transform.position + playerMovement * Time.deltaTime * speed);
        //rb.velocity = playerMovement * Time.deltaTime * speed;
    }
}
