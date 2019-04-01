using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Objective
{
    Animator anim;
    GameObject cam;
    AudioSource audioSource;

    public override void Start()
    {
        audioSource = GetComponent<AudioSource>();
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        anim = GetComponent<Animator>();

        base.Start();
    }

    public override void PerformAction()
    {
        anim.SetBool("OpenDoor", true);
        audioSource.Play();
        StartCoroutine(cam.GetComponent<CameraFollow>().CameraShake(0.1f, 0.02f));
    }
}
