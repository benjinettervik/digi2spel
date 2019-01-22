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
                    isCompleted = true;
                    ActivateObjects();
                }
                else
                {
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

    public override void ActionToBePerformed(bool enable)
    {

    }
}
