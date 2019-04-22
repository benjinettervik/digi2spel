using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRoom : MonoBehaviour
{
    //Denna ska endas tickas om det är ett rum spelaren spawnar i
    public bool isStartingRoom;

    public GameObject roomToDisable;
    public GameObject roomToEnable;

    public bool effect;

    private void Start()
    {
        if (!isStartingRoom)
        {
            SetRoomCoversState(roomToEnable, false);
        }
    }

    public bool hasEntered;
    private void OnTriggerEnter(Collider other)
    {
        if (!hasEntered)
        {
            if (other.name == "Player")
            {
                hasEntered = true;
                //ChangeRoomState(roomToEnable, true);
                if (effect)
                    SetRoomCoversState(roomToEnable, true);
                //ChangeRoomState(roomToDisable, false);
                if (effect)
                    SetRoomCoversState(roomToDisable, false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            hasEntered = false;
        }
    }

    void SetRoomCoversState(GameObject room, bool state)
    {
        GameObject covers;
        covers = room.transform.Find("Covers").gameObject;

        foreach (Transform cover in covers.transform)
        {
            StartCoroutine(ChangeColor(cover.gameObject, state));
        }
    }

    IEnumerator ChangeColor(GameObject objectToChange, bool state)
    {
        Material objectColor = objectToChange.GetComponent<EditMaterial>().objectMaterial;

        if (state)
        {
            while (objectColor.color.a > 0)
            {
                objectColor.color -= new Color(0, 0, 0, 2f * Time.deltaTime);
                yield return null;
            }
        }
        else
        {
            while (objectColor.color.a < 1)
            {
                objectColor.color += new Color(0, 0, 0, 2f * Time.deltaTime);
                yield return null;
            }
        }
    }
}
