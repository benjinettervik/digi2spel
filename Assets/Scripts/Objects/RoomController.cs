using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    bool roomCompleted;

    public List<GameObject> objectives;
    public GameObject objectiveToToggle;

    int completedObjectives;
    public void CheckObjectiveCompleted()
    {
        completedObjectives = 0;
        foreach (GameObject objective in objectives)
        {
            if (!objective.GetComponent<Objective>().isCompleted)
            {
                return;
            }
        }

        print("doing shit");
        if (!roomCompleted)
        {
            objectiveToToggle.GetComponent<Objective>().PerformAction();
            roomCompleted = true;
        }
    }
}
