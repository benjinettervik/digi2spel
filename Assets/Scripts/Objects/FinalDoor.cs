using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoor : Objective
{
    public List<GameObject> mainKeys = new List<GameObject>();

    public override void Start()
    {
        base.Start();
    }

    public void EnterKey()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        playerInteract.Think("hmm... four key holes?", 0, 0);
    }
}
