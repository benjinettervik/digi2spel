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

    Animator anim;

    float timeSinceStep;
    [SerializeField]
    float stepFrequency = 0.3f;

    public bool isMoving;

    float currentMovingSpeed;

    private void Start()
    {
        lastPos = transform.position;

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        cc = GetComponent<CharacterController>();
        playerSounds = transform.Find("Sounds").GetComponent<PlayerSounds>();
    }

    float xMovement;
    float yMovement;
    private void Update()
    {
        anim.SetFloat("TimeScale", Time.timeScale);

        currentMovingSpeed = (lastPos - transform.position).magnitude;
        isMoving = CheckIfMoving();

        Gravity();
        SetAnimation();

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

    public void Footstep1()
    {
        print("step");
        playerSounds.PlayStep();
    }

    public void Footstep2()
    {
        playerSounds.PlayStep();
    }

    void SetAnimation()
    {
        if (isMoving)
        {
            print("is moving");
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
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
