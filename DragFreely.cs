using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragFreely : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler 
{
	public static GameObject itemBeingDragged;
	public Vector3 OffsetVector;
	Vector3 startPosition;
	public bool CanDrag;
    public bool StorageInteractionLock;
	public GameObject togg;
	
	#region IBeginDragHandler implementation
	public void OnBeginDrag (PointerEventData eventData)
	{
		itemBeingDragged = gameObject;
		startPosition = transform.position;
	}
	#endregion
	
	#region IDragHandler implementation
	public void OnDrag (PointerEventData eventData)
	{
		if (CanDrag == true && StorageInteractionLock == false) 
		{
			transform.position = Input.mousePosition - OffsetVector;
		}
		else
		{
			transform.position = startPosition;
		}
	}
	#endregion
	
	#region IEndDragHandler implementation
	
	public void OnEndDrag (PointerEventData eventData)
	{
		itemBeingDragged = null;
	}
	
	#endregion

	void ToggleDrag()
	{
		CanDrag = !togg.GetComponent<Toggle>().isOn;
	}

	
}
