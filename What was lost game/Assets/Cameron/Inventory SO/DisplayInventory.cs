using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayInventory : MonoBehaviour
{
    public GameObject inventoryPage, inventorySlot;
    public InventoryObject inventory;
    public Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();

    private void Start()
    {
        inventoryPage = GameObject.Find("Page Inventory");

        CreateDisplay();
    }

    private void Update()
    {
        UpdateDisplay();
    }

    private void CreateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            var newSlot = Instantiate(inventorySlot);
            newSlot.transform.SetParent(inventoryPage.transform);
        }
    }

   
    private void UpdateDisplay()
    {
    }
}
