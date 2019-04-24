using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : ChestItem
{
    public override void PickUp()
    {
        base.PickUp();

        GameObject.FindGameObjectWithTag("GameController").GetComponent<Controller>().AddKey(gameObject);
        gameObject.SetActive(false);
    }
}
