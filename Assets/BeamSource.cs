using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamSource : MonoBehaviour
{
    LineRenderer line;

    private void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        InitiateBeam();
    }

    void InitiateBeam()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 50))
        {
            Debug.DrawLine(transform.position, transform.position + transform.forward * hit.distance, Color.green);
            print("yeet");
            if (hit.collider.tag == "Mirror")
            {
                print("hit mirror");
                Debug.DrawLine(hit.point, hit.point + Vector3.Reflect(hit.collider.transform.position - transform.position,
                    hit.normal), Color.green);

                //InitiateBeam();

            }
        }
    }
}
