using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Objective
{
    Animator anim;
    GameObject cam;

    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        anim = GetComponent<Animator>();
    }

    public override void PerformAction()
    {
        anim.SetBool("OpenDoor", true);
        StartCoroutine(cam.GetComponent<CameraFollow>().CameraShake(0.1f, 0.02f));
    }
}
