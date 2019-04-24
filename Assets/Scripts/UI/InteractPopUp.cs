using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractPopUp : MonoBehaviour
{
    public GameObject popUpText;
    GameObject currentText;
    GameObject parent;

    bool hasBeenInteracted;
    //hur många ggr man interagerar med objektet
    public int interactionAmount;
    bool isInTrigger;

    int timesInteracted;

    private void Start()
    {
        parent = transform.parent.gameObject;
    }

    private void Update()
    {
        if (isInTrigger)
        {
            if (Input.GetButtonDown("Interact") && !hasBeenInteracted)
            {
                currentText.GetComponent<PopUpText>().OnClick();
                parent.GetComponent<Interactable>().OnClick();

                timesInteracted++;

                if (interactionAmount == timesInteracted)
                {
                    StartCoroutine(DestroyTextAfterTime(0.1f));
                    hasBeenInteracted = true;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !hasBeenInteracted)
        {
            isInTrigger = true;
            DisplayText();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && !hasBeenInteracted)
        {
            isInTrigger = false;
            if (currentText != null)
            {
                Destroy(currentText.transform.parent.gameObject);
            }
        }
    }

    void DisplayText()
    {
        currentText = Instantiate(popUpText);
        currentText = currentText.transform.GetChild(0).gameObject;
        currentText.GetComponent<PopUpText>().InstantiateSetup(parent, "E", Vector3.zero);
    }

    //denna funktion är till om objektet bara interageras en gång, så förstörs texten efter feedback animationen
    IEnumerator DestroyTextAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        if (currentText != null)
        {
            Destroy(currentText.transform.parent.gameObject);
        }
    }
}
