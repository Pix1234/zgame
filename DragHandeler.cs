using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragHandeler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler 
{
	public static GameObject itemBeingDragged;
	
	public Vector3 OffsetVector;
	Vector3 startPosition;
	Transform startParent;
	Transform canvas;


    #region IBeginDragHandler implementation
    public void OnBeginDrag(PointerEventData eventData)
    {
        itemBeingDragged = gameObject;
        startPosition = transform.position;
        startParent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        if (itemBeingDragged.GetComponent<ItemCollisionDetection>().CharCont.GetComponent<Stats>() == null)
        {
            itemBeingDragged.transform.SetParent(itemBeingDragged.GetComponent<ItemCollisionDetection>().SlotOn.GetComponent<SlotHolder>().SlotsMain.GetComponent<StorageDistanceDetection>().Belonger.GetComponent<Storage>().currentlyInteractingInstance.GetComponent<Stats>().UnReadyItemsUI.transform);
            itemBeingDragged.GetComponent<ItemCollisionDetection>().Inv = itemBeingDragged.GetComponent<ItemCollisionDetection>().SlotOn.GetComponent<SlotHolder>().SlotsMain.GetComponent<StorageDistanceDetection>().Belonger.GetComponent<Storage>().currentlyInteractingInstance.GetComponent<Stats>().UnReadyItemsUI;
            itemBeingDragged.GetComponent<ItemCollisionDetection>().CharCont = itemBeingDragged.GetComponent<ItemCollisionDetection>().SlotOn.GetComponent<SlotHolder>().SlotsMain.GetComponent<StorageDistanceDetection>().Belonger.GetComponent<Storage>().currentlyInteractingInstance;
        }
        if (itemBeingDragged.GetComponent<AmmoData>() == true)
        {
            if (itemBeingDragged.GetComponent<ItemCollisionDetection>().Ammoed == true)
            {
                itemBeingDragged.GetComponent<RectTransform>().sizeDelta = itemBeingDragged.GetComponent<ItemCollisionDetection>().OriginalSize;
            }
            itemBeingDragged.GetComponent<ItemCollisionDetection>().Ammoed = false;
        }
        itemBeingDragged.GetComponent<ItemCollisionDetection> ().SlotOn = null;
    }
	#endregion
	
	#region IDragHandler implementation
	public void OnDrag (PointerEventData eventData)
	{
		transform.position = Input.mousePosition - OffsetVector;
	}
	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	{

		itemBeingDragged = null;
		GetComponent<CanvasGroup> ().blocksRaycasts = true;
	}

	#endregion


}
