using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    bool followMouse;
    Transform lastPos;

    private void Update()
    {
        print(followMouse);
        SetPosition();
    }

    public void FollowMouse()
    {
        followMouse = true;
    }

    public void StopFollowingMouse()
    {
        followMouse = false;
    }

    void SetPosition()
    {
        if (followMouse)
        {
            transform.position = Input.mousePosition;
        }
    }
}
