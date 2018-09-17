using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject slotsParent;
    public List<GameObject> slots;
    public List<GameObject> itemImages;
    public Transform imagesParent;

    private void Start()
    {
        AssignSlots();
    }

    void AssignSlots()
    {
        foreach (Transform child in slotsParent.transform)
        {
            slots.Add(child.gameObject);
        }
    }

    public void AddItemAndImage(GameObject currentObject, GameObject itemImage)
    {
        slots.Add(currentObject);
        var image = Instantiate(itemImage, slots[slots.Count].transform.position, Quaternion.identity, imagesParent);
        itemImages.Add(image);
    }
}
