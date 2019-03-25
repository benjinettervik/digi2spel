using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Mirror : Objective
{
    public bool isFinalMirror;
    public bool hasHitFinalMirror;

    private void Update()
    {
        if (isInTrigger)
        {
            RotateMirror();
        }
    }

    public void MirrorBeam(Vector3 hitPoint, Vector3 _reflectedVector, int n, BeamSource beamSource)
    {
        beamSource.linePoints.Add(hitPoint);

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
                if (hit.collider.tag == "BeamTarget")
                {
                    hit.collider.GetComponent<Objective>().PerformAction();
                }

                beamSource.linePoints.Add(hit.point);
                print(gameObject.name + " is setting final mirror");
                beamSource.SetLineRenderer();
            }

            Debug.DrawLine(hitPoint, hitPoint + _reflectedVector * hit.distance, Color.green);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            DisplayText();
            currentText.transform.GetChild(0).GetComponent<PopUpText>().InstantiateSetup(gameObject, "Q    E", new Vector3(0, 0, 0.2f));
            currentText.transform.GetChild(0).GetComponent<Text>().fontSize += 10;

            isInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isInTrigger = false;
            DestroyText();
        }

    }
    void RotateMirror()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            transform.localEulerAngles -= new Vector3(0, 10, 0) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.localEulerAngles += new Vector3(0, 10, 0) * Time.deltaTime;
        }
    }
}