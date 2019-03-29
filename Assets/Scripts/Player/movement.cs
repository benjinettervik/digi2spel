using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    Rigidbody rb;
    CharacterController cc;
    PlayerSounds playerSounds;

    Vector3 playerMovement;
    Vector3 lastPos;

    [SerializeField]
    float speed;
    [SerializeField]
    float accelerationSpeed;
    [SerializeField]
    int invertDir = 1;

    float timeSinceStep;
    [SerializeField]
    float stepFrequency = 0.3f;

    float currentMovingSpeed;

    private void Start()
    {
        lastPos = transform.position;

        rb = GetComponent<Rigidbody>();
        cc = GetComponent<CharacterController>();
        playerSounds = transform.Find("Sounds").GetComponent<PlayerSounds>();
    }

    float xMovement;
    float yMovement;
    private void Update()
    {
        currentMovingSpeed = (lastPos - transform.position).magnitude;

        Gravity();
        PlayStep();

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

        playerMovement = new Vector3(yMovement, 0, -xMovement).normalized;
        cc.Move(playerMovement * Time.deltaTime * speed);
    }

    void Gravity()
    {
        if (!cc.isGrounded)
        {
            //TODO lägga till gravitationsacceleration
            cc.Move(new Vector3(0, -9.82f, 0));
        }
    }

    void PlayStep()
    {
        if (CheckIfMoving())
        {
            timeSinceStep += Time.deltaTime;
            if (timeSinceStep > stepFrequency)
            {
                playerSounds.PlayStep();
                timeSinceStep = 0;
            }
        }
        else
            timeSinceStep = 0;
    }


    bool CheckIfMoving()
    {
        if (lastPos != transform.position)
        {
            lastPos = transform.position;
            return true;
        }

        lastPos = transform.position;
        return false;
    }
}
