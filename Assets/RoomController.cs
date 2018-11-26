using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public List<GameObject> objectives;
    public GameObject objectiveToToggle;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            objectives[0].GetComponent<Objective>().isCompleted = true;
        }
    }

    public void CheckObjectiveCompleted()
    {
        foreach(GameObject objective in objectives)
        {
            if (!objective.GetComponent<Objective>().isCompleted)
            {
                return;
            }

            print("doing shit");
            objectiveToToggle.GetComponent<Objective>().PerformAction();
        }
    }
}
