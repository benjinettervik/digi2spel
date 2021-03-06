﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditMaterial : MonoBehaviour
{
    [HideInInspector]
    public Material objectMaterial;

    public List<Material> materials = new List<Material>();

    [Header("Bug Fix")]
    public bool isQuad;

    private void Awake()
    {
        //buggfix, kan se igenom av nån anledning om detta inte görs 
        if (isQuad)
        {
            Material tempMat = GetComponent<MeshRenderer>().materials[0];
            tempMat.color = Color.black;
        }

        CreateMaterial();
    }

    void CreateMaterial()
    {
        MeshRenderer meshRenderer;
        SkinnedMeshRenderer skinnedMeshRenderer;

        if (meshRenderer = GetComponent<MeshRenderer>() ?? null)
        {
            meshRenderer.material = new Material(meshRenderer.materials[0]);
            objectMaterial = GetComponent<MeshRenderer>().material;

            foreach (Material material in meshRenderer.materials)
            {
                materials.Add(material);
            }
        }

        else if (skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>() ?? null)
        {
            GetComponent<SkinnedMeshRenderer>().material = new Material(GetComponent<SkinnedMeshRenderer>().materials[0]);
            objectMaterial = GetComponent<SkinnedMeshRenderer>().material;

            foreach (Material material in skinnedMeshRenderer.materials)
            {
                materials.Add(material);
            }
        }
    }
}
