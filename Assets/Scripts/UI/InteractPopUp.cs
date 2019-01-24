using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractPopUp : MonoBehaviour
{
    public GameObject popUpText;
    GameObject currentText;
    GameObject parent;

    //om objektet bara blir interactad med en gång
    bool hasBeenInteracted;
    //denna checkar man i inspektorn
    public bool oneTimeInteraction;
    bool isInTrigger;

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
                hasBeenInteracted = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !hasBeenInteracted)
        {
            isInTrigger = true;
            DisplayText();

            if (oneTimeInteraction)
            {
                StartCoroutine(DestroyTextAfterTime());
            }
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
    IEnumerator DestroyTextAfterTime()
    {
        yield return new WaitForSeconds(0.7f);
        if (currentText != null)
        {
            Destroy(currentText.transform.parent.gameObject);
        }
    }
}
