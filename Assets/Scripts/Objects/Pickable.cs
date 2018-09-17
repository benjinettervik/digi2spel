using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    InventoryOld inventory;
    public GameObject itemImage;

    private void Start()
    {
        //hitta inventory scriptet
        inventory = GameObject.Find("InventoryMainPiece").GetComponent<InventoryOld>();
    }

    public void PickUp()
    {
        //kalla funktionen i inventorysrkriptet och lägg till objektet i inventory, sedan göm sig objektet
        inventory.AddAndDisplayItem(gameObject, itemImage);

        gameObject.SetActive(false);
    }

    private void Update()
    {
        //PLACEHOLDER
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PickUp();
        }
    }
}