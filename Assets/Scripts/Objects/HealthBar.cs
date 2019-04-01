using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    Canvas canvas;
    Camera cam;

    Vector3 direction;
    GameObject linkedObject;

    [SerializeField]
    bool isEnemyHealthBar;

    private void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<Canvas>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        transform.SetParent(canvas.transform);
    }

    private void Update()
    {
        if (isEnemyHealthBar)
        {
            transform.position = cam.WorldToScreenPoint(linkedObject.transform.position + direction);
        }
    }

    public void Setup(GameObject _linkedObject, Vector3 _direction)
    {
        linkedObject = _linkedObject;
        direction = _direction;
    }
}
