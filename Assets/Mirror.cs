using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    // :)
    public bool isFinalMirror;
    public bool hasHitFinalMirror;

    public void MirrorBeam(Vector3 hitPoint, Vector3 _reflectedVector, int n, BeamSource beamSource)
    {
        beamSource.linePoints.Add(transform.position);

        if (n > 60) { Debug.Log("Infinite loop?"); return; }
        RaycastHit hit;
        if (Physics.Raycast(hitPoint, _reflectedVector, out hit, 50))
        {
            if (hit.collider.tag == "Mirror" && hit.collider.gameObject != gameObject)
            {
                print("hit mirror");
                Vector3 reflectedVector = Vector3.Reflect(_reflectedVector, hit.normal);
                hit.collider.GetComponent<Mirror>().MirrorBeam(hit.point, reflectedVector, n, beamSource);

                if (isFinalMirror)
                {
                    hasHitFinalMirror = true;
                }
            }

            else
            {
                beamSource.linePoints.Add(hit.point);
                print(gameObject.name + " is setting final mirror");
                beamSource.SetLineRenderer();
            }


            Debug.DrawLine(hitPoint, hitPoint + _reflectedVector * hit.distance, Color.green);
        }
    }
}