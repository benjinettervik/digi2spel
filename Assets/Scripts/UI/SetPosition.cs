using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPosition : MonoBehaviour
{
    //detta skriptet är dumt men hade nåt konstigt bug
    GameObject textPos;
    GameObject player;
    Camera cam;

    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        player = GameObject.FindGameObjectWithTag("Player");
        textPos = player.transform.Find("Textpos").gameObject;
    }

    private void Update()
    {
        transform.position = cam.WorldToScreenPoint(textPos.transform.position);
    }
}
