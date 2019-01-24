using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPosition : MonoBehaviour
{
    //detta skriptet är dumt men hade nåt konstigt bug
    [SerializeField]
    public GameObject textPos;
    Camera cam;

    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    private void Update()
    {
        transform.position = cam.WorldToScreenPoint(textPos.transform.position);
    }
}
