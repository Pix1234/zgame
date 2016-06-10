using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AmmoSlotHolder : MonoBehaviour, IDropHandler
{
    public GameObject MyAmmoSlot;

    #region IDropHandler implementation
    public void OnDrop(PointerEventData eventData)
    {
        if (DragHandeler.itemBeingDragged.GetComponent<AmmoData>() == true)
        {
            if (MyAmmoSlot.transform.childCount < 1)
            {
                DragHandeler.itemBeingDragged.GetComponent<ItemCollisionDetection>().Ammoed = true;
                DragHandeler.itemBeingDragged.GetComponent<ItemCollisionDetection>().OriginalSize = DragHandeler.itemBeingDragged.GetComponent<RectTransform>().sizeDelta;
                DragHandeler.itemBeingDragged.transform.SetParent(transform);
                DragHandeler.itemBeingDragged.transform.position = transform.position;
            }
        }
    }
    #endregion
}
