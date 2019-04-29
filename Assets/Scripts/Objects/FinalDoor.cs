using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoor : Objective
{
    GameObject gameController;

    public override void Start()
    {
        base.Start();

        gameController = GameObject.FindGameObjectWithTag("GameController");
    }

    private void Update()
    {
        if (isInTrigger)
        {
            if (Input.GetButtonDown("Interact"))
            {
                StartCoroutine(OnClick());
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isInTrigger = true;
            //detta är placeholder
            if (gameController.GetComponent<Controller>().keyImages[0].gameObject.activeInHierarchy)
            {
                DisplayText(gameObject, "E", Vector3.up, 0);
            }

            else
            {
                playerInteract.Think(playerInteract.needKey, 210, 10);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isInTrigger = false;
            DestroyText();
        }
    }

    IEnumerator OnClick()
    {
        currentText.transform.GetChild(0).GetComponent<PopUpText>().OnClick();

        GetComponent<Animator>().Play("DoorOpen");
        GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(8);

        StartCoroutine(gameController.GetComponent<FadeIn>().FadeInImage(true));

        yield return new WaitForSeconds(2);

        //gameController.GetComponent<LoadScene>().LoadCustomScene("Menu_real");
    }
}
