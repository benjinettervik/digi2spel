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
        //transform.parent är för smooth kamera, så kan den vara smooth fast det är camera shake
        transform.parent.position = Vector3.SmoothDamp(transform.position, camPos.transform.position, ref referV, 0.6f);
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
