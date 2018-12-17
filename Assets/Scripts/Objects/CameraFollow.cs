using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    public GameObject camPos;
    Vector3 referV = Vector3.zero;

    private void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        transform.position = Vector3.SmoothDamp(transform.position, camPos.transform.position, ref referV, 0.6f);
    }
}
