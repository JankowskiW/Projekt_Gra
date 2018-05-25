using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    public GameObject inventoryUI;
    public GameObject mainCamera;
    public GameObject mapUI;

    Inventory inventory;
    InventorySlot[] slots;

    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            Cursor.visible = inventoryUI.activeSelf;
            Cursor.lockState = inventoryUI.activeSelf ? CursorLockMode.None : CursorLockMode.Locked;
            mainCamera.GetComponent<thirdpersonCamera>().enabled = !inventoryUI.activeSelf;
            Time.timeScale = inventoryUI.activeSelf ? 0 : 1;
            mapUI.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && inventoryUI.activeSelf)
        {   
            inventoryUI.SetActive(false);
            Cursor.visible = inventoryUI.activeSelf;
            Cursor.lockState = inventoryUI.activeSelf ? CursorLockMode.None : CursorLockMode.Locked;
            mainCamera.GetComponent<thirdpersonCamera>().enabled = !inventoryUI.activeSelf;
            Time.timeScale = inventoryUI.activeSelf ? 0 : 1;
        }


    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
