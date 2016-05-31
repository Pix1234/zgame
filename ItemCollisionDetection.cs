using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemCollisionDetection : MonoBehaviour 
{
	public int itemID;
	public int Colided;
	public GameObject itemDataBase;
	public GameObject Inv;
	public GameObject CharCont;
	public GameObject SlotOn;
	public GameObject DropDown;
    public GameObject CollidingItemInstance;
	public Transform ParentOfSlot;
	public bool Good;
	public bool CollidingItem;
    public bool Ammoed;

	public Vector3 posOffseter;
	Vector2 colSize;
    public Vector2 OriginalSize;

	public Color NeutralColor;
	public Color PlacedColor;
    public Color AmmoedColor;

    void Start () 
	{
		gameObject.GetComponent<DragHandeler> ().OffsetVector.x = itemDataBase.GetComponent<ItemDatabase> ().items [itemID].dragOffset.x;
		gameObject.GetComponent<DragHandeler> ().OffsetVector.y = itemDataBase.GetComponent<ItemDatabase> ().items [itemID].dragOffset.y;
		posOffseter = new Vector3(itemDataBase.GetComponent<ItemDatabase> ().items [itemID].cellSize.x,(-itemDataBase.GetComponent<ItemDatabase> ().items [itemID].cellSize.y),0);

		colSize = new Vector2 (gameObject.GetComponent<RectTransform> ().rect.size.x-1, gameObject.GetComponent<RectTransform> ().rect.size.y-1);
		gameObject.GetComponent<BoxCollider2D> ().size = colSize;

		
	}
	

	void Update ()
    {
        if (Ammoed == false)
        {
            if (CollidingItem == false && Colided == itemDataBase.GetComponent<ItemDatabase>().items[itemID].amountOfSlots && SlotOn != null && SlotOn.GetComponent<SlotHolder>().SlotsMain.GetComponent<StorageDistanceDetection>().Detected == false)
            {
                Good = true;
            }
            else
            {
                Good = false;
            }
        }
        else
        {
            Good = true;
        }

        if (Ammoed == false)
        {
            if (Good == true)
            {
                transform.SetParent(SlotOn.GetComponent<SlotHolder>().SlotsParent.transform);
                gameObject.GetComponent<Image>().color = PlacedColor;
                DropdownHide();
            }
            else
            {
                transform.SetParent(Inv.transform);
                gameObject.GetComponent<Image>().color = NeutralColor;
            }
        }
        else
        {
            gameObject.GetComponent<Image>().color = AmmoedColor;
        }
        //Debugger
       /* if (CollidingItem != false)
        {
            Debug.Log("Colldiing with another item");
        }
        if (Colided != itemDataBase.GetComponent<ItemDatabase>().items[itemID].amountOfSlots)
        {
            Debug.Log("Not colliding with enough slots");
        }
        if (SlotOn == null)
        {
            Debug.Log("Not attached to slot");
        }
        if (SlotOn.GetComponent<SlotHolder>().SlotsMain.GetComponent<StorageDistanceDetection>().Detected != false)
        {
            Debug.Log("Storage is too close");
        }*/
        



    }
    
    
    void OnCollisionStay2D(Collision2D coll) 
	{

		if (coll.gameObject.tag == "DragItem")
		{
			CollidingItem = true;
            CollidingItemInstance = coll.gameObject;
		}

	}
	void OnCollisionExit2D(Collision2D coll) 
	{

		if (coll.gameObject.tag == "Slot")
		{
			Colided -= 1;
		}
        

        if (coll.gameObject.tag == "DragItem")
		{
			CollidingItem = false;
		}
	}
	void OnCollisionEnter2D(Collision2D coll) 
	{
		if (coll.gameObject.tag == "Slot")
		{
            
			Colided += 1;
		}
        
    }

	void DropdownToggle()
	{
		if (Good == false) 
		{
			DropDown.SetActive (!DropDown.activeInHierarchy);
		}
	}
	void DropdownHide()
	{
		DropDown.SetActive (false);
	}
}
