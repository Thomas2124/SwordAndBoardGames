using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


//Call the drag handle function, IDragHandler Is required to start draging, and add a drag event. While Begin and End are only requied to create
//End and start events for draging operations. I = interface
public class DragAndDropScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	//Setup Script to find Audiosource automatically
	//public AudioSource sourceDrag;
	public AudioClip dragSound;
	public Transform parentToReturnTo = null;
	//Sets an Event for the start of the drag process
	public void OnBeginDrag(PointerEventData eventData)
	{
		//Debug.Log ("OnBDrag");
		parentToReturnTo = this.transform.parent;
		this.transform.SetParent(this.transform.parent.parent);
		//Causes the item being draged to ignore raycast
		GetComponent<CanvasGroup>().blocksRaycasts = false;
		PlaySound();
		//EventSystem.current.RaycastAll(eventData){if()}
	}
	//Sets an Event for the Middle of the drag process
	public void OnDrag(PointerEventData eventData)
	{
		//Debug.Log ("OnDrag");
		//Actually Drags the object	
		this.transform.position = eventData.position;
	}
	//Sets an Event for the end of the drag process
	public void OnEndDrag(PointerEventData eventData)
	{
		//Debug.Log ("OnEDrag");
		this.transform.SetParent(parentToReturnTo);
		//Causes the item being draged to stop ignoring raycast		
		GetComponent<CanvasGroup>().blocksRaycasts = true;
	}
	
	void PlaySound()
	{
		//sourceDrag.PlayOneShot(dragSound);	
	}
}
