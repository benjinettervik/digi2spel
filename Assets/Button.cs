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

    private void Update()
    {
        print(isEnabled);
    }

    public override void ActionToBePerformed(bool enable)
    {
        isEnabled = enable;

        if (enable)
        {
            print("starting light");
            StopCoroutine(ToggleLight(3, true));
            StartCoroutine(ToggleLight(3, true));
        }
        else if (!enable)
        {
            print("disabling light");
            StopCoroutine(ToggleLight(0, false));
            StartCoroutine(ToggleLight(0, false));
        }

    }

    public IEnumerator ToggleLight(float intensity, bool lightState)
    {
        if (lightState)
        {
            while (light.intensity <= intensity)
            {
                print("enabling light literally");
                light.intensity += Time.deltaTime * 10;

                if (!isEnabled)
                {
                    StartCoroutine(ToggleLight(0, false));
                    break;
                }

                yield return false;
            }
        }
        else if (!lightState)
        {
            while (light.intensity >= intensity)
            {
                print("disabling light literally");
                light.intensity -= Time.deltaTime * 10;

                if (isEnabled)
                {
                    StartCoroutine(ToggleLight(3, true));
                    break;
                }

                if (light.intensity <= 0)
                {
                    break;
                }

                yield return false;
            }
        }
        yield return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isEnabled)
        {
            if (other.tag == "Sword")
            {
                print("=????");
                if (other.transform.parent.GetComponent<Sword>().isActive)
                {
                    isCompleted = true;
                    roomController.GetComponent<RoomController>().CheckObjectiveCompleted();
                }
            }
        }
    }
}
