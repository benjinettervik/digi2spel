using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Objective
{
    Light light;
    bool isInTrigger;
    public bool isEnabled;
    public GameObject popUpText;

    Material mat;

    private void Start()
    {
        mat = GetComponent<EditMaterial>().objectMaterial;
    }

    private void Update()
    {
        print(isEnabled);

        if (isInTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                OnClick();
            }
        }
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
            while (mat.GetColor("_EmissionColor").r < 1.5f)
            {
                print(mat.GetColor("_EmissionColor").r);
                mat.SetColor("_EmissionColor", mat.GetColor("_EmissionColor") + new Color(Time.deltaTime, Time.deltaTime, Time.deltaTime) * 10);

                if (!isEnabled)
                {
                    StartCoroutine(ToggleLight(0, false));
                    break;
                }

                yield return false;
            }
        }
        else
        {
            while (mat.GetColor("_EmissionColor").r > 0)
            {
                print(mat.GetColor("_EmissionColor").r);
                mat.SetColor("_EmissionColor", mat.GetColor("_EmissionColor") - new Color(Time.deltaTime, Time.deltaTime, Time.deltaTime) * 10);

                if (isEnabled)
                {
                    StartCoroutine(ToggleLight(0, true));
                    break;
                }

                yield return false;
            }
        }

        yield return false;
    }

    GameObject currentText;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            DisplayText();
            isInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        print("exit");
        if (other.tag == "Player")
        {
            Destroy(currentText);
            isInTrigger = false;
        }
    }

    void OnClick()
    {
        isCompleted = true;
        roomController.GetComponent<RoomController>().CheckObjectiveCompleted();
    }

    void DisplayText()
    {
        currentText = Instantiate(popUpText);
        if (isEnabled)
        {
            currentText.GetComponent<PopUpText>().InstantiateSetup(gameObject, "press E to click button");
        }
        else
        {
            currentText.GetComponent<PopUpText>().InstantiateSetup(gameObject, "button is disabled");
        }
    }
}
