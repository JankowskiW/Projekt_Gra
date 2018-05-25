using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {

    public Image icon;
    public Item item;
    public bool isEmpty = true;
    //public GameObject itemPrefab;

    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        isEmpty = false;
        //itemPrefab = newItem;
       // removeButton.interactable = true;
    }
    
    public void ClearSlot()
    {
        item = null;
        isEmpty = true;

        icon.sprite = null;
        icon.enabled = false;
       // itemPrefab = null;
       // removeButton.interactable = false;
    }
    
   /* public void OnRemoveButton()
    {
        Inventory.instance.Remove(item);
    }*/
}
