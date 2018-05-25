using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

    public GameObject dropItem;         // wyrzucanie itemów
    public GameObject childObject;
    public Transform taggedParent;
    public Transform taggedParentDrag;
    public Transform dropItemArea;
    private static GameObject playerRef;
    GameObject droppedObject;

    Item[] currentEquipment;
    EquipmentManager equipment;
    Inventory inventory;

    public void Start()
    {
        equipment = EquipmentManager.instance;
        inventory = Inventory.instance;
        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Item[numSlots];
        playerRef = GameObject.Find("Overlord");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
       // Debug.Log("OnPointerEnter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Debug.Log("OnPointerExit");
    }

    public void OnDrop(PointerEventData eventData)
    {
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        ItemPickup i;
        taggedParentDrag = d.taggedParentDrag; // tag Inventory slotu z którego podnosimy
        InventorySlot iSlot = eventData.pointerDrag.GetComponent<InventorySlot>();
        InventorySlot iSlotDrag;

        if (d.parentToReturnTo.transform.position != this.transform.position)
        {
            if(this.transform.name == "Panel")
            {
                float angle = UnityEngine.Random.Range(0.0f, Mathf.PI * 2);
                Vector3 v = new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle));
                droppedObject = (GameObject)GameObject.Instantiate(dropItem, playerRef.transform.position - v, Quaternion.identity);
            
                Debug.Log("Dropped Item: " + droppedObject);
                i = droppedObject.GetComponent<ItemPickup>();
                i.item = iSlot.item;
                Debug.Log("ITEM:" + i.item + ", iSotITEM: " + iSlot.item);

                inventory.Remove(i.item);

                /* NALEŻY DOPISA KOD, ABY DOBRZE DZIAŁAŁO USUWANIE Z EKWIPUNKU BEZPOŚREDNIO I ABY
                 * ITEM USUNIĘTY Z EKWIPUNKU PO PODNIESIENIU TRAFIAŁ DO INWENTARZA A NIE EKWIPUNKU
                 * 
                 * można to łatwo zrobić w taki sposób, że sprawdzamy przy usuwaniu czy item był usuwany ze slotów
                 * otagowanych ekwipunek czy inwentarz, jeśli ekwipunek to najpierw jest dodawany do inwentarza a usuwany z ekwipunku 
                 * a następnie usuwany z inwentarza tak jak powyżej
                 */
            }
            else
            { 
                childObject = transform.Find("Icon").gameObject;
                taggedParent = childObject.transform.parent.parent; // rodzic elementu na który upuszczamy item
                iSlotDrag = childObject.GetComponent<InventorySlot>(); // Item na który upuszczamy (skrypt inventory slot)
                if (taggedParent.tag == "InventorySlot")
                {
                    if(taggedParentDrag.tag != "InventorySlot")
                    {
                        if (iSlotDrag.isEmpty)
                        {
                            /* poniższy kod umożliwia usunięcie itemu z ekwipunku i umieszczenie go
                             * na pustym miejscu w inwentarzu
                             */
                            equipment.Equip((int)iSlot.item.equipSlot); // przekazuje dragnietego nie dropnietego
                            if (d != null)
                            {
                              //  Debug.Log(eventData.pointerDrag.name + " was dropped on " + taggedParent.tag);
                                childObject.transform.SetParent(d.parentToReturnTo);
                                childObject.transform.position = d.parentToReturnTo.transform.position;
                                d.parentToReturnTo = this.transform;
                            }
                        }
                        else if (iSlotDrag.item.equipSlot == iSlot.item.equipSlot)
                        {   
                            /* poniższy kod umożliwia zamianę itemów o takim samym przeznaczeniu między
                             * ekwipunek -> inventarz 
                             */
                            equipment.Equip(iSlotDrag.item, iSlot.item);
                            if (d != null)
                            {
                             //   Debug.Log(eventData.pointerDrag.name + " was dropped on " + taggedParent.tag);
                                childObject.transform.SetParent(d.parentToReturnTo);
                                childObject.transform.position = d.parentToReturnTo.transform.position;
                                d.parentToReturnTo = this.transform;
                            }
                        }
                    }else 
                    {
                        /* poniższy kod umożliwia zamianę miejscami itemów o różnym przeznaczeniu między
                         * inventarz -> inventarzz
                         * ale nie umożliwia takie zamiany między:
                         * inventarz -> ekwipunek
                         * ekwipunek -> inwentarz
                         * ekwipunek -> ekwipunek
                         */
                        if (d != null)
                        {
                          //  Debug.Log(eventData.pointerDrag.name + " was dropped on " + taggedParent.tag);
                            childObject.transform.SetParent(d.parentToReturnTo);
                            childObject.transform.position = d.parentToReturnTo.transform.position;
                            d.parentToReturnTo = this.transform;
                        }

                    }
                
                } //  END OF if (taggedParent.tag == "InventorySlot")
                else if(taggedParent.tag == iSlot.item.equipSlot.ToString())
                {
                    /* poniższy kod umożliwia zamianę itemów o takim samym przeznaczeniu między
                     * inventarz -> inventarz
                     */
                    equipment.Equip(iSlot.item,iSlotDrag.item);
                    if (d != null)
                    {
                     //   Debug.Log(eventData.pointerDrag.name + " was dropped on " + taggedParent.tag);
                        childObject.transform.SetParent(d.parentToReturnTo);
                        childObject.transform.position = d.parentToReturnTo.transform.position;
                        d.parentToReturnTo = this.transform;

                    }
                } // END OF  if (taggedParent.tag == "InventorySlot") { ... } else if(taggedParent.tag == iSlot.item.equipSlot.ToString())
            }

        } // END OF if (d.parentToReturnTo.transform.position != this.transform.position)
    }
}