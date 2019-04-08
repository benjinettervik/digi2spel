using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Objective
{
    public bool isEnabled;
    Animator anim;
    Material mat;

    public override void Start()
    {
        anim = GetComponent<Animator>();
        mat = GetComponent<EditMaterial>().materials[1];

        base.Start();
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
            ToggleLight(3, true);
            ToggleLight(3, true);
        }
        else if (!enable)
        {
            ToggleLight(0, false);
            ToggleLight(0, false);
        }
    }

    public void ToggleLight(float intensity, bool lightState)
    {
        if (lightState)
        {
            mat.color = Color.green;
            mat.SetColor("_EmissionColor", Color.green * 7);
            /* while (mat.GetColor("_EmissionColor").g < 1th.5f)
             {
                 mat.SetColor("_EmissionColor", mat.GetColor("_EmissionColor") + new Color(0, Time.deltaTime, 0) * 10);

                 if (!isEnabled)
                 {
                     StartCoroutine(ToggleLight(0, false));
                     break;
                 }

                 yield return false;
             }
             */
        }
        else
        {
            mat.color = Color.red;
            mat.SetColor("_EmissionColor", Color.red * 7);
            /*
            while (mat.GetColor("_EmissionColor").g > 0)
            {
                mat.SetColor("_EmissionColor", mat.GetColor("_EmissionColor") - new Color(0, Time.deltaTime, 0) * 10);

                if (isEnabled)
                {
                    StartCoroutine(ToggleLight(0, true));
                    break;
                }

                yield return false;
            }
            */
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player = other.gameObject;
            DisplayText(gameObject, "E", Vector3.up / 3, 0);
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

        if (isEnabled)
        {
            anim.Play("lever_pull");
            isCompleted = true;
            roomController.GetComponent<RoomController>().CheckObjectiveCompleted();
        }
        else
        {
            anim.Play("lever_pull_fake");
            playerInteract.Think(playerInteract.buttonDisabled, 120, 0);
        }
    }
}
