using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    public bool isCompleted;
    public GameObject roomController;
    public GameObject[] objectivesToActivate;
    public GameObject[] objectivesToDeActivate;

    public virtual void PerformAction()
    {

    }

    public virtual void ActionToBePerformed(bool enable)
    {

    }

    public void ActivateObjects()
    {
        foreach (GameObject objective in objectivesToActivate)
        {
            objective.GetComponent<Objective>().ActionToBePerformed(true);
        }
    }
    public void DeActivateObjects()
    {
        foreach (GameObject objective in objectivesToDeActivate)
        {
            objective.GetComponent<Objective>().ActionToBePerformed(false);
        }
    }
}