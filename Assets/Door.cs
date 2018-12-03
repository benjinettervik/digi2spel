using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Objective
{
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public override void PerformAction()
    {
        anim.SetBool("OpenDoor", true);
    }
}
