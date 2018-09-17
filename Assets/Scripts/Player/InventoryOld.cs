using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryOld : MonoBehaviour
{
    public List<GameObject> inventorySlots;
    public List<GameObject> itemsInInventory;
    public List<GameObject> itemImages;

    public GameObject inventorySlotsParent;
    public GameObject itemImagesParent;
    public GameObject selectedObject;
    public GameObject selectedSlot;

    bool inventoryIsOpen = true;
    int currentSlotNumber;

    private void Start()
    {
        AddAllSlotsToList();
        selectedSlot.transform.position = inventorySlots[0].transform.position;
    }

    private void Update()
    {
        if (inventoryIsOpen)
        {
            MoveSelectedSlot();
        }
    }

    public void AddAndDisplayItem(GameObject currentObject, GameObject objectImage)
    {
        itemsInInventory.Add(currentObject);
        int itemAdded = itemsInInventory.Count;
        objectImage.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        itemImages[itemAdded].SetActive(true);
    }

    void MoveSelectedSlot()
    {
        if (inventoryIsOpen)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                SetSelectedObject(1);
            }

            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                SetSelectedObject(-1);
            }

            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                SetSelectedObject(8);
            }

            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                SetSelectedObject(-8);
            }
        }
    }

    void AddAllSlotsToList()
    {
        foreach (Transform child in inventorySlotsParent.transform)
        {
            print("adding slots");
            inventorySlots.Add(child.gameObject);
        }

        foreach(Transform child in itemImagesParent.transform)
        {
            itemImages.Add(child.gameObject);
        }
    }

    void SetSelectedObject(int forwardorbackward)
    {
        print(currentSlotNumber);
        if (currentSlotNumber + forwardorbackward <= inventorySlots.Count - 1 && currentSlotNumber + forwardorbackward >= 0)
        {
            currentSlotNumber += forwardorbackward;
            selectedSlot.transform.position = inventorySlots[currentSlotNumber].transform.position;
            selectedObject = inventorySlots[currentSlotNumber];
        }
    }
}
