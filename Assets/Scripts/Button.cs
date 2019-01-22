using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Objective
{
    Light light;
    bool isInTrigger;
    public bool isEnabled;
    public GameObject popUpText;
    GameObject player;
    Material mat;

    private void Start()
    {
        mat = GetComponent<EditMaterial>().objectMaterial;
    }

    private void Update()
    {
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
            player = other.gameObject;
            DisplayText();
            isInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(currentText);
            isInTrigger = false;
        }
    }

    void OnClick()
    {
        currentText.transform.GetChild(0).GetComponent<PopUpText>().OnClick();
        if (isEnabled)
        {
            isCompleted = true;
            roomController.GetComponent<RoomController>().CheckObjectiveCompleted();
        }
        else
        {
            player.GetComponent<PlayerPopUpText>().Think("Seems like this button is disabled..");
        }
    }

    void DisplayText()
    {
        currentText = Instantiate(popUpText);
        currentText.transform.GetChild(0).GetComponent<PopUpText>().InstantiateSetup(gameObject, "E", new Vector3(0, 0, 0.2f));
    }
}
