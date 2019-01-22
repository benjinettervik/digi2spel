using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpText : MonoBehaviour
{
    GameObject linkedObject;
    GameObject canvas;
    Text textObject;
    Camera mainCam;
    bool hasBeenSetup;


    private void Awake()
    {
        canvas = GameObject.FindGameObjectWithTag("MainCanvas");
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        textObject = GetComponent<Text>();
        transform.parent = canvas.transform;
    }

    private void Update()
    {
        if (hasBeenSetup)
        {
            transform.position = mainCam.WorldToScreenPoint(linkedObject.transform.position + (Vector3.up / 2));
        }
    }

    public void InstantiateSetup(GameObject _linkedObject, string text)
    {
        linkedObject = _linkedObject;
        transform.position = mainCam.WorldToScreenPoint(linkedObject.transform.position + (Vector3.up / 2));
        textObject.text = text;

        hasBeenSetup = true;
    }
}
