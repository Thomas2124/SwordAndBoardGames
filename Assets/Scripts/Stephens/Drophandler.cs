using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//Interface Drop Handler controlls droping to allow for drop events
public class Drophandler : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{

	//Identifies if the object is being droped
	public void OnDrop(PointerEventData eventData)
	{
		Debug.Log ("OnDrop to " + gameObject.name);
		
		DragAndDropScript d = eventData.pointerDrag.GetComponent<DragAndDropScript>();
		if(d != null)
		{
			d.parentToReturnTo = this.transform;
		}
		
	}
	//detects if the mouse enters an area with the associated script
	public void OnPointerEnter(PointerEventData eventData)
	{
		//Debug.Log ("Onpoint");
	}
	//detects if the mouse leaves an area with the associated script
	public void OnPointerExit(PointerEventData eventData)
	{
		//Debug.Log ("EndPoint");
	}
}
