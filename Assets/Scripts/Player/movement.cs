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

    [SerializeField]
    int invertDir = 1;

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
        Gravity();

        xMovement += Input.GetAxisRaw("Vertical") * Time.deltaTime * accelerationSpeed * invertDir;
        yMovement -= Input.GetAxisRaw("Horizontal") * Time.deltaTime * accelerationSpeed * invertDir;

        if (Input.GetAxisRaw("Vertical") == 0)
        {
            xMovement = Mathf.Lerp(xMovement, 0, 1f);
        }

        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            yMovement = Mathf.Lerp(yMovement, 0, 1f);
        }

        xMovement = Mathf.Clamp(xMovement, -1, 1);
        yMovement = Mathf.Clamp(yMovement, -1, 1);

        playerMovement = new Vector3(yMovement, 0, -xMovement);
        cc.Move(playerMovement * Time.deltaTime * speed);
    }

    void Gravity()
    {
        if (!cc.isGrounded)
        {
            //TODO lägga till gravitationacceleration
            cc.Move(new Vector3(0, -9.82f, 0));
        }
    }
}
