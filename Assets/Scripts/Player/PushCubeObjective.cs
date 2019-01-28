using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushCubeObjective : Objective
{
    public GameObject designatedPosition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == designatedPosition.name)
        {
            isCompleted = true;
            print("hit");
            roomController.GetComponent<RoomController>().CheckObjectiveCompleted();
            ActivateObjects();
        }
    }
}
