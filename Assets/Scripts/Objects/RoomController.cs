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

    [Header("Denna tickas om fienden MÅSTE dödas")]
    public bool needToKillEnemies;
    [Header("Alla fiender som måste dödas")]
    public GameObject[] enemiesToKill;

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

        if (!roomCompleted)
        {
            objectiveToToggle.GetComponent<Objective>().PerformAction();
            roomCompleted = true;
        }
    }

    private void Update()
    {
        CheckEnemies();
    }

    void CheckEnemies()
    {
        foreach (GameObject enemy in enemiesToKill)
        {
            if (enemy != null)
            {
                return;
            }
        }

        CheckObjectiveCompleted();
    }
}
