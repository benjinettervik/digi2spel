using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutWeightOnPlate : Objective
{
    public string[] possibleTags;

    void CheckCollision(string collidingTag, bool enable)
    {
        foreach (string tag in possibleTags)
        {
            if (tag == collidingTag)
            {
                if (enable)
                {
                    GetComponent<EditMaterial>().materials[1].color = Color.green;
                    GetComponent<EditMaterial>().materials[1].SetColor("_EmissionColor", Color.green);

                    isCompleted = true;
                    ActivateObjects();
                }
                else
                {
                    GetComponent<EditMaterial>().materials[1].color = Color.red;
                    GetComponent<EditMaterial>().materials[1].SetColor("_EmissionColor", Color.red);

                    isCompleted = false;
                    DeActivateObjects();
                }

                roomController.GetComponent<RoomController>().CheckObjectiveCompleted();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        CheckCollision(other.tag, true);
    }
    private void OnTriggerExit(Collider other)
    {
        CheckCollision(other.tag, false);
    }

    private void OnTriggerStay(Collider other)
    {
        CheckCollision(other.tag, true);
    }

    public override void ActionToBePerformed(bool enable)
    {

    }
}
