using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamSource : MonoBehaviour
{
    LineRenderer line;
    public List<Vector3> linePoints;

    bool hasHitNewPoint;
    int dontIgnoreLayers;

    Vector3 lastHitPoint;

    private void Start()
    {
        dontIgnoreLayers = 1 << LayerMask.NameToLayer("Default");
        line = GetComponent<LineRenderer>();
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.L))
        {
            GetComponent<LineRenderer>().SetPosition(0, new Vector3(Random.Range(-5, 5), 0));
        }
        InitiateBeam(transform.position);
    }

    void InitiateBeam(Vector3 startPos)
    {
        linePoints = new List<Vector3>();
        linePoints.Add(transform.position);

        RaycastHit hit;

        if (Physics.Raycast(startPos, transform.forward, out hit, 1000, dontIgnoreLayers, QueryTriggerInteraction.Ignore))
        {
            if (hit.collider.tag == "Mirror")
            {
                print("hit mirror");

                Vector3 reflectedVector = Vector3.Reflect(transform.forward, hit.normal);
                hit.collider.transform.parent.GetComponent<Mirror>().MirrorBeam(hit.point, reflectedVector, 0, gameObject.GetComponent<BeamSource>());
            }
            else
            {
                linePoints.Add(hit.point);
                SetLineRenderer();
            }

            Debug.DrawLine(startPos, startPos + transform.forward * hit.distance, Color.green);
        }

    }

    [SerializeField]
    Vector3[] linePointsArray;

    public int linePointsInActualLineRenderer;
    public void SetLineRenderer()
    {
        print("Setting line renderer with " + linePoints.Count + " positions");
        linePointsArray = linePoints.ToArray();
        line.positionCount = linePointsArray.Length;
        line.SetPositions(linePointsArray);

        foreach (Vector3 linePoint in linePointsArray)
        {
            Debug.DrawLine(linePoint, linePoint + transform.up * 3, Color.blue);
        }
    }
}
