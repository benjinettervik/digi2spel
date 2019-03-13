using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamSource : MonoBehaviour
{
    LineRenderer line;
    List<Vector3> linePoints;

    bool hasHitNewPoint;

    Vector3 lastHitPoint;

    private void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        InitiateBeam(transform.position);
    }

    void InitiateBeam(Vector3 startPos)
    {
        RaycastHit hit;

        if (Physics.Raycast(startPos, transform.forward, out hit, 50))
        {
            if (hit.collider.tag == "Mirror")
            {
                print("hit mirror");

                hit.collider.GetComponent<Mirror>().MirrorBeam(hit.point);
            }

            Debug.DrawLine(startPos, startPos + transform.forward * hit.distance, Color.green);

            /*
            lastHitPoint = hit.point;

            if (hasHitNewPoint)
            {
                linePoints = new List<Vector3>();
                linePoints.Add(transform.position);
                linePoints.Add(hit.point);
                SetLineRenderer(linePoints);

                hasHitNewPoint = false;
            }
            */

        }
    }

    void SetLineRenderer(List<Vector3> linePoints)
    {
        Vector3[] linePointsArray = new Vector3[linePoints.Count];
        linePointsArray = linePoints.ToArray();

        line.SetPositions(linePointsArray);
    }
}
