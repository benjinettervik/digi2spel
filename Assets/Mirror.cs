using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    // :)
    public void MirrorBeam(Vector3 hitPoint)
    {
        RaycastHit hit;
        if (Physics.Raycast(hitPoint, transform.forward, out hit, 50))
        {
            if (hit.collider.tag == "Mirror")
            {
                print("hit mirror");

            }
            Debug.DrawLine(hitPoint, hitPoint + transform.forward * hit.distance, Color.green);
        }

    }

    IEnumerator MirrorOtherBeam(RaycastHit hit)
    {
        yield return new WaitForSeconds(0.034f);
        hit.collider.GetComponent<Mirror>().MirrorBeam(hit.point);
    }

}