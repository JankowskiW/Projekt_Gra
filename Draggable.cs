using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    public Transform parentToReturnTo = null;
    public Transform taggedParentDrag;
    public Transform onEndDragObject = null;

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("OnBeginDrag");
        taggedParentDrag = this.transform.parent.parent;
        //Debug.Log("taggedParentDrag on Draggable.cs is " + taggedParentDrag);
        parentToReturnTo = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent.parent.parent.parent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag");
        this.transform.position = eventData.position;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //onEndDragObject = this.transform.parent.parent;
        //Debug.Log("onEndDragObject.draggable: " + onEndDragObject);
        this.transform.SetParent(parentToReturnTo);
        this.transform.position = parentToReturnTo.transform.position;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        parentToReturnTo = null;
        taggedParentDrag = null;

    }
}
