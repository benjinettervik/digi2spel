using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public List<GameObject> objectives;
    public GameObject objectiveToToggle;

    int completedObjectives;
    public void CheckObjectiveCompleted()
    {
        completedObjectives = 0;
        foreach (GameObject objective in objectives)
        {
            if (objective.GetComponent<Objective>().isCompleted)
            {
                completedObjectives++;
            }

            if (completedObjectives == objectives.Count)
            {
                print("doing shit");
                objectiveToToggle.GetComponent<Objective>().PerformAction();
            }
        }
    }
}
