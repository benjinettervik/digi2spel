using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushCubeObjective : Objective
{
    public GameObject roomController;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            isCompleted = true;
            print("hit");
            roomController.GetComponent<RoomController>().CheckObjectiveCompleted();
        }
    }
}
