using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamSource : MonoBehaviour
{
    LineRenderer line;
    public List<Vector3> linePoints;

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
        linePoints = new List<Vector3>();
        linePoints.Add(transform.position);

        RaycastHit hit;

        if (Physics.Raycast(startPos, transform.forward, out hit, 50))
        {
            if (hit.collider.tag == "Mirror")
            {
                print("hit mirror");

                Vector3 reflectedVector = Vector3.Reflect(transform.forward, hit.normal);
                hit.collider.GetComponent<Mirror>().MirrorBeam(hit.point, reflectedVector, 0, this);
            }

            else
            {
                linePoints.Add(hit.point);
                //SetLineRenderer();
            }

            Debug.DrawLine(startPos, startPos + transform.forward * hit.distance, Color.green);

        }

    }

    private void OnDrawGizmos()
    {
        foreach(Vector3 linePoint in linePoints)
        {
            Debug.DrawLine(linePoint, linePoint + transform.up * 3, Color.blue);
        }
    }


    [SerializeField]
    Vector3[] linePointsArray;

    public int linePointsInActualLineRenderer;
    public void SetLineRenderer()
    {
        linePointsArray = linePoints.ToArray();
        line.SetPositions(linePointsArray);
    }
}
