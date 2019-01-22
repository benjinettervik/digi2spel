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
    Animator anim;
    bool hasBeenSetup;

    private void Awake()
    {
        canvas = GameObject.FindGameObjectWithTag("MainCanvas");
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        textObject = GetComponent<Text>();
        anim = GetComponent<Animator>();
        transform.parent.parent = canvas.transform;
    }

    private void Update()
    {
        if (hasBeenSetup)
        {
            transform.parent.position = mainCam.WorldToScreenPoint(linkedObject.transform.position + (Vector3.up / 2) + direction);
        }
    }

    public void OnClick()
    {
        anim.Play("E_to_interact_click");
    }

    Vector3 direction;
    public void InstantiateSetup(GameObject _linkedObject, string text, Vector3 _direction)
    {
        direction = _direction;
        linkedObject = _linkedObject;
        textObject.text = text;

        hasBeenSetup = true;
    }
}
