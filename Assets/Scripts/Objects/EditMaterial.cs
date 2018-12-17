using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditMaterial : MonoBehaviour
{
    public Material objectMaterial;

    private void Awake()
    {
       CreateMaterial();
    }

    void CreateMaterial()
    {
        GetComponent<MeshRenderer>().material = new Material(GetComponent<MeshRenderer>().materials[0]);

        objectMaterial = GetComponent<MeshRenderer>().material;
    }
}
