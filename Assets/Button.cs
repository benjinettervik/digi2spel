using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Objective
{
    Light light;
    public bool isEnabled;

    private void Awake()
    {
        light = transform.Find("Point Light").GetComponent<Light>();
    }

    public override void ActionToBePerformed()
    {
        print("starting light");
        StartCoroutine(ToggleLight(3, true));
    }

    public IEnumerator ToggleLight(float intensity, bool lightState)
    {
        while (light.intensity <= intensity)
        {
            light.intensity += Time.deltaTime * 10;
            yield return false;
        }

        isEnabled = lightState;
        yield return false;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (isEnabled)
        {

            if (other.tag == "Sword")
            {
                if (other.transform.parent.GetComponent<Sword>().isActive)
                {
                    print("compketeing");
                    isCompleted = true;
                    roomController.GetComponent<RoomController>().CheckObjectiveCompleted();
                }
            }
        }
    }
}
