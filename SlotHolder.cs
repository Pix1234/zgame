using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class SlotHolder : MonoBehaviour, IDropHandler 
{
	public GameObject SlotsParent;
    public GameObject SlotsMain;



	#region IDropHandler implementation
	public void OnDrop (PointerEventData eventData)
	{
		DragHandeler.itemBeingDragged.transform.position = DragHandeler.itemBeingDragged.gameObject.GetComponent<ItemCollisionDetection> ().posOffseter+transform.position;
		DragHandeler.itemBeingDragged.GetComponent<ItemCollisionDetection> ().SlotOn = transform.gameObject;
	}
	#endregion


}
