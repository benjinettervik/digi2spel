using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    bool roomCompleted;

    [Header("Alla objekt i rummet")]
    public List<GameObject> objectives;
    [Header("Sista saken som händer i rummet, t.ex. dörren öppnas")]
    public GameObject objectiveToToggle;
    public List<GameObject> enemies;

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
        if (enemies.Count == 0)
        {
            objectiveToToggle.GetComponent<Objective>().PerformAction();
            roomCompleted = true;
        }
    }
}
