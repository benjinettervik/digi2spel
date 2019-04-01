using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    Canvas canvas;
    Camera cam;

    Vector3 direction;
    GameObject linkedObject;

    private void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<Canvas>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        transform.SetParent(canvas.transform);
    }

    private void Update()
    {
        transform.position = cam.WorldToScreenPoint(linkedObject.transform.position + direction);
    }

    public void Setup(GameObject _linkedObject, Vector3 _direction)
    {
        linkedObject = _linkedObject;
        direction = _direction;
    }
}
