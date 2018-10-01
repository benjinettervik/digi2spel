using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRoom : MonoBehaviour
{
    //Denna ska endas assignas om det är ett rum spelaren spawnar i
    public GameObject startingRoom;

    public GameObject roomToDisable;
    public GameObject roomToEnable;

    private void Start()
    {
        if (roomToEnable != startingRoom)
        {
            ChangeRoomState(roomToEnable, false);

        }
    }

    bool hasEntered;
    private void OnTriggerEnter(Collider other)
    {
        if (!hasEntered)
        {
            hasEntered = true;

            if (other.name == "Player")
            {
                ChangeRoomState(roomToEnable, true);
                ChangeRoomState(roomToDisable, false);
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

    void ChangeRoomState(GameObject room, bool state)
    {
        foreach (Transform objectInRoom in room.transform)
        {
            if (objectInRoom.GetComponent<MeshRenderer>() != null)
            {
                objectInRoom.GetComponent<MeshRenderer>().enabled = state;
            }
        }
    }
}
