using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPos : MonoBehaviour
{
    GameObject player;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        transform.position = player.transform.position + new Vector3(-8, 10, 0);
    }
}
