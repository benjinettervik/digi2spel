using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditMaterial : MonoBehaviour
{
    public Material objectMaterial;
    
    public List<Material> materials = new List<Material>();

    private void Awake()
    {
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
                Debug.Log("found material", gameObject);
                materials.Add(material);
            }
        }
    }
}
