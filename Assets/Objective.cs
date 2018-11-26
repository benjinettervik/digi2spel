using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    public bool isCompleted;
    public GameObject roomController;
    public GameObject[] objectivesToActivate;

    public virtual void PerformAction()
    {

    }

    public virtual void ActionToBePerformed()
    {

    }

    public void ActivateObjects()
    {
        foreach (GameObject objective in objectivesToActivate)
        {
            objective.GetComponent<Objective>().ActionToBePerformed();
        }
    }
}