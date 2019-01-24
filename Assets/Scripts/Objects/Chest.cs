using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactable
{
    Animator anim;
    BoxCollider boxColl;
    public GameObject objectToSpawn;

    private void Awake()
    {
        boxColl = GetComponent<BoxCollider>();
        anim = GetComponent<Animator>();
    }

    public override void OnClick()
    {
        anim.Play("ChestOpen");

        //eftersom kistan expanderar när man öppnar den måste box collidern bli större
        boxColl.center = new Vector3(boxColl.center.x, boxColl.center.y, -1.3f);
        boxColl.size = new Vector3(boxColl.size.x, boxColl.size.y, 5);
    }

    void SpawnObject()
    {

    }
}
