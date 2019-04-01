using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamTarget : Objective
{
    public override void PerformAction()
    {
        print("objective completed");

        isCompleted = true;

        roomController.GetComponent<RoomController>().CheckObjectiveCompleted();
        ActivateObjects();
    }
}
