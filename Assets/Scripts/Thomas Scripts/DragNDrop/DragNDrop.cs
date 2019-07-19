using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragNDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject item;
    Vector3 startPosition;
    Transform startParent;
    
    //Starts as soon as the player clicks on a dragable object
    public void OnBeginDrag(PointerEventData eventData)
    {
        item = gameObject;
        startPosition = transform.position;
        startParent = transform.parent; //sets variable to the orignal parent
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    //This is used while the object is being drag
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition; //gets current mouse position
    }

    //Resets item position and parent if the object cant be placed
    public void OnEndDrag(PointerEventData eventData)
    {
        item = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        if (transform.parent == startParent)
        {
            transform.position = startPosition;
        }
    }
}
