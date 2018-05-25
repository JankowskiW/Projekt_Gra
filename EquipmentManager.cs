using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour {

    #region Singleton
    public static EquipmentManager instance;
    void Awake()
    {
        instance = this;
    }
    #endregion

    Item[] currentEquipment;
    PlayerStats playerStats;

    Inventory inventory;
    void Start()
    {
        inventory = Inventory.instance;
        playerStats = PlayerStats.instance;
        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length - 1;
        currentEquipment = new Item[numSlots];
    }

    public void Equip (Item newItem, Item oldItem)
    {
        Debug.Log("newItem = " + newItem);
        int slotIndex = (int)newItem.equipSlot;
        currentEquipment[slotIndex] = newItem;
        // Aktualizacja statystyk gracza
        playerStats.OnEquipmentChanged(newItem, oldItem);
    }

    public void Equip (int slotIndex)
    {
        // Aktualizacja statystyk gracza
        playerStats.OnEquipmentChanged(null, currentEquipment[slotIndex]);
       // Debug.Log(currentEquipment[slotIndex]);
        currentEquipment[slotIndex] = null;
    }
}
