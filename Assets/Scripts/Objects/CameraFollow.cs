using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    public GameObject camPos;
    Vector3 referV = Vector3.zero;
    Vector3 lastMousePos;

    [SerializeField]
    float lookSpeed;

    private void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        //transform.parent är för smooth kamera, så kan den vara smooth fast det är camera shake
        if (Input.GetKey(KeyCode.Mouse1))
        {
            Vector3 horizontalMoveDir = lastMousePos - Input.mousePosition;
            Vector3 verticalMoveDir = lastMousePos - Input.mousePosition;

            transform.parent.position += new Vector3(horizontalMoveDir.x * 0.3f, 0, horizontalMoveDir.y * 0.3f) * -lookSpeed;

            lastMousePos = Input.mousePosition;
        }
        else
        {
            transform.parent.position = Vector3.SmoothDamp(transform.position, camPos.transform.position, ref referV, 0.6f);
            lastMousePos = Input.mousePosition;
        }
    }

    float timePassed;
    public IEnumerator CameraShake(float _intenseness, float decreaseFactor)
    {
        while (_intenseness > 0)
        {
            timePassed += Time.deltaTime;
            _intenseness -= Time.deltaTime * decreaseFactor;
            transform.position = transform.parent.position + Random.insideUnitSphere * _intenseness;
            yield return false;
        }
        transform.position = transform.parent.position;
    }
}
