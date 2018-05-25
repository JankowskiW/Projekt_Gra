using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable {
    public static int tmp;
    public Item item;
    bool canPickUp = false;
    
    void Start () {
       canPickUp = false;
    }

    public override void Interact()
    {
        base.Interact();
        PickUp();
    }

    void PickUp()
    {
        if (Input.GetKeyDown(KeyCode.E) && canPickUp)
        {
            // Debug.Log("Picking up " + item.name);
            /*if (gameObject.transform.tag == "DropItem")
            {
                ItemPickup i;
                i = gameObject.GetComponent<ItemPickup>();
                i.item = null;
            }*/
            bool wasPickedUp = Inventory.instance.Add(item);
            if (wasPickedUp)
            {
                Destroy(gameObject);
                Debug.Log("tmp: " + tmp);
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            canPickUp = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        canPickUp = false;
    }
    
}
