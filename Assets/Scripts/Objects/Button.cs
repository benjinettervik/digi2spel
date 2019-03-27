using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Objective
{
    bool isInTrigger;
    public bool isEnabled;
    Animator anim;
    GameObject player;
    Material mat;

    private void Start()
    {
        anim = GetComponent<Animator>();
        mat = GetComponent<EditMaterial>().objectMaterial;
    }

    private void Update()
    {
        if (isInTrigger)
        {
            if (Input.GetButtonDown("Interact"))
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
            StopCoroutine(ToggleLight(3, true));
            StartCoroutine(ToggleLight(3, true));
        }
        else if (!enable)
        {
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
            DestroyText();
            isInTrigger = false;
        }
    }

    void OnClick()
    {
        currentText.transform.GetChild(0).GetComponent<PopUpText>().OnClick();
        PlayerPopUpText interactClass = player.GetComponent<PlayerPopUpText>();

        anim.Play("button_press");

        if (isEnabled)
        {
            isCompleted = true;
            roomController.GetComponent<RoomController>().CheckObjectiveCompleted();
        }
        else
        {
            interactClass.Think(interactClass.buttonDisabled);
        }
    }
}
