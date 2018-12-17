using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject sword;
    Animator swordAnim;

    private void Update()
    {
        swordAnim = sword.GetComponent<Animator>();
    }

    void AttackOnClick()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            
        }
    }
}
