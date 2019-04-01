using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamTarget : Objective
{
    Coroutine setEmission;

    public override void Start()
    {
        base.Start();

        GetComponent<EditMaterial>().objectMaterial.SetColor("_EmissionColor", new Color(0, 0, 0));
    }

    public override void PerformAction()
    {
        base.PerformAction();

        isCompleted = true;

        roomController.GetComponent<RoomController>().CheckObjectiveCompleted();

        if (!(setEmission == null))
        {
            StopCoroutine(setEmission);
        }

        setEmission = StartCoroutine(SetEmission(true));

        ActivateObjects();
    }

    public override void DisperformAction()
    {
        base.DisperformAction();

        if (!(setEmission == null))
        {
            StopCoroutine(setEmission);
        }

        setEmission = StartCoroutine(SetEmission(false));
        DeActivateObjects();
    }

    IEnumerator SetEmission(bool on)
    {
        Material mat = GetComponent<EditMaterial>().objectMaterial;

        if (on)
        {
            mat.EnableKeyword("_EMISSION");
            while (mat.GetColor("_EmissionColor").r < 1.5f)
            {
                mat.SetColor("_EmissionColor", mat.GetColor("_EmissionColor") + new Color(Time.deltaTime, 0, 0) * 10);

                yield return false;
            }
        }
        else if (!on)
        {
            while (mat.GetColor("_EmissionColor").r > 0f)
            {
                mat.SetColor("_EmissionColor", mat.GetColor("_EmissionColor") - new Color(Time.deltaTime, 0, 0) * 10);

                yield return false;
            }
        }
    }

}
