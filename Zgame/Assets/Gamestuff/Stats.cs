using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Stats : MonoBehaviour 
{


	public float CharacterHealth;
	public float CharacterHunger;
	public float CharacterThirst;
	public float CharacterStamina;
	public float CharacterAdrenaline;
	public float CharacterBlood;
	public float CharacterSainity;
	public float CharacterEnergy;
	public float CharacterBodyTemp;

	public float MaxMainWidth;
	public float MaxSecondaryWidth;
    public float DropForce;

	public bool inventoryOn;
	public bool toggleMainStatsShow;
	public bool ResetColided;
	public bool BackpackAlone;

	public GameObject MainStatsUI;
	public GameObject InventoryUI;
	public GameObject BackpackUI;
	public GameObject UnReadyItemsUI;
	public GameObject ItemsInBackpack;
	public GameObject WeaponSlotsUI;
    public GameObject StorageUI;
    public GameObject HandsUI;
    public GameObject BackUI;
    public GameObject HandsAmmoUI;
    public GameObject BackAmmoUI;
    public GameObject SafeBackpackUIPosition;
    public GameObject SafeStorageUIPosition;

	public GameObject BarHealth;
	public GameObject BarHunger;
	public GameObject BarThirst;
	public GameObject BarStamina;
	public GameObject BarAdrenaline;
	public GameObject BarBlood;
	public GameObject BarSainity;
	public GameObject BarEnergy;

	public GameObject prefab;

	public GameObject ItemDB;

	public GameObject cln;

    public GameObject ItemDropper;

	void Start()
	{


	}



	public void InstantiatePickupItem(int itmID)
	{
		GameObject clone = Instantiate(ItemDB.GetComponent<ItemDatabase>().items[itmID].itemPickupPrefab, transform.position, Quaternion.identity) as GameObject;
		
	}
    public void InstantiateInventoryItem(int itmID)
    {
        GameObject clone = (GameObject)Instantiate(ItemDB.GetComponent<ItemDatabase>().items[itmID].itemDragDropPrefab, InventoryUI.transform.position, Quaternion.identity);

        clone.GetComponent<ItemCollisionDetection>().itemDataBase = ItemDB;
        clone.transform.SetParent(UnReadyItemsUI.transform);
        clone.GetComponent<ItemCollisionDetection>().Inv = UnReadyItemsUI;
        clone.GetComponent<ItemCollisionDetection>().CharCont = gameObject;
    }
    public void InstantiatePickupItemConsumable(int itmID, GameObject itmInstance)
    {
        GameObject clone = Instantiate(ItemDB.GetComponent<ItemDatabase>().items[itmID].itemPickupPrefab, transform.position, Quaternion.identity) as GameObject;
        clone.GetComponent<Pickup>().ConsumedProgress = itmInstance.GetComponent<ItemAction_StatsEditorItem>().ConsumedProgress;
        clone.transform.position = ItemDropper.transform.position;
        clone.GetComponent<Rigidbody>().AddForce(ItemDropper.transform.forward * DropForce);

    }
    public void InstantiatePickupItemAmmo(int itmID, GameObject itmInstance)
    {
        GameObject clone = Instantiate(ItemDB.GetComponent<ItemDatabase>().items[itmID].itemPickupPrefab, transform.position, Quaternion.identity) as GameObject;
        clone.GetComponent<AmmoPickup>().AmmoLeft = itmInstance.GetComponent<AmmoData>().BulletsLeft;
        clone.transform.position = ItemDropper.transform.position;
        clone.GetComponent<Rigidbody>().AddForce(ItemDropper.transform.forward * DropForce);
    }
    public void InstantiateInventoryItemConsumable(int itmID, GameObject itmInstance)
    {
        GameObject clone = (GameObject)Instantiate(ItemDB.GetComponent<ItemDatabase>().items[itmID].itemDragDropPrefab, InventoryUI.transform.position, Quaternion.identity);

        clone.GetComponent<ItemCollisionDetection>().itemDataBase = ItemDB;
        clone.transform.SetParent(UnReadyItemsUI.transform);
        clone.GetComponent<ItemCollisionDetection>().Inv = UnReadyItemsUI;
        clone.GetComponent<ItemCollisionDetection>().CharCont = gameObject;
        clone.GetComponent<ItemAction_StatsEditorItem>().ConsumedProgress = itmInstance.GetComponent<Pickup>().ConsumedProgress;

    }
    public void InstantiateInventoryItemAmmo(int itmID, GameObject itmInstance)
    {
        GameObject clone = (GameObject)Instantiate(ItemDB.GetComponent<ItemDatabase>().items[itmID].itemDragDropPrefab, InventoryUI.transform.position, Quaternion.identity);

        clone.GetComponent<ItemCollisionDetection>().itemDataBase = ItemDB;
        clone.transform.SetParent(UnReadyItemsUI.transform);
        clone.GetComponent<ItemCollisionDetection>().Inv = UnReadyItemsUI;
        clone.GetComponent<ItemCollisionDetection>().CharCont = gameObject;
        clone.GetComponent<AmmoData>().BulletsLeft = itmInstance.GetComponent<AmmoPickup>().AmmoLeft;

    }
    public void InstantiateWeaponSlotted(int itmID)
    {

        if (HandsUI.transform.childCount < 1)
        {
            GameObject clone = (GameObject)Instantiate(ItemDB.GetComponent<WeaponDatabase>().weapons[itmID].weaponDragDropPrefab, InventoryUI.transform.position, Quaternion.identity);
            clone.transform.SetParent(HandsUI.transform);
            HandsUI.GetComponent<GridLayoutGroup>().cellSize = ItemDB.GetComponent<WeaponDatabase>().weapons[itmID].sizeInSlot;
        }
        else if (BackUI.transform.childCount < 1)
        {
            GameObject clone = (GameObject)Instantiate(ItemDB.GetComponent<WeaponDatabase>().weapons[itmID].weaponDragDropPrefab, InventoryUI.transform.position, Quaternion.identity);
            clone.transform.SetParent(BackUI.transform);
            BackUI.GetComponent<GridLayoutGroup>().cellSize = ItemDB.GetComponent<WeaponDatabase>().weapons[itmID].sizeInSlot;
        }
        else
        {
            Debug.Log("Not enough space...");
        }
    }
    
    public void InstantiateWeaponPickup(int itmID)
    {
        GameObject clone = Instantiate(ItemDB.GetComponent<WeaponDatabase>().weapons[itmID].weaponPickupPrefab, transform.position, Quaternion.identity) as GameObject;
        clone.transform.position = ItemDropper.transform.position;
        clone.GetComponent<Rigidbody>().AddForce(ItemDropper.transform.forward * DropForce);
    }


    void Update()
	{
        if (HandsUI.transform.childCount > 0)
        {
            HandsUI.GetComponent<WeaponSlotController>().Containing = HandsUI.transform.GetChild(0).gameObject;
            HandsUI.GetComponent<GridLayoutGroup>().cellSize = ItemDB.GetComponent<WeaponDatabase>().weapons[HandsUI.GetComponent<WeaponSlotController>().Containing.GetComponent<WeaponSlotted>().WeaponID].sizeInSlot;
            if (HandsAmmoUI.transform.childCount > 0)
            {
                HandsUI.GetComponent<WeaponSlotController>().ContainingMag = HandsAmmoUI.transform.GetChild(0).gameObject;
                HandsAmmoUI.GetComponent<GridLayoutGroup>().cellSize = ItemDB.GetComponent<AmmoDatabase>().ammo[HandsAmmoUI.transform.GetChild(0).GetComponent<AmmoSlotted>().AmmoID].sizeInSlot;
            }
            else
            {
                HandsUI.GetComponent<WeaponSlotController>().ContainingMag = null;
            }
        }
        else
        {
            HandsUI.GetComponent<WeaponSlotController>().Containing = null;
        }
        if (BackUI.transform.childCount > 0)
        {
            BackUI.GetComponent<WeaponSlotController>().Containing = BackUI.transform.GetChild(0).gameObject;
            BackUI.GetComponent<GridLayoutGroup>().cellSize = ItemDB.GetComponent<WeaponDatabase>().weapons[BackUI.GetComponent<WeaponSlotController>().Containing.GetComponent<WeaponSlotted>().WeaponID].sizeInSlot;
            if (BackAmmoUI.transform.childCount > 0)
            {
                BackUI.GetComponent<WeaponSlotController>().ContainingMag = BackAmmoUI.transform.GetChild(0).gameObject;
                BackAmmoUI.GetComponent<GridLayoutGroup>().cellSize = ItemDB.GetComponent<AmmoDatabase>().ammo[BackAmmoUI.transform.GetChild(0).GetComponent<AmmoSlotted>().AmmoID].sizeInSlot;
            }
            else
            {
                BackUI.GetComponent<WeaponSlotController>().ContainingMag = null;
                
            }
        }
        else
        {
            BackUI.GetComponent<WeaponSlotController>().Containing = null;
        }

        BarHealth.GetComponent<RectTransform>().localScale = new Vector3(CharacterHealth/100,BarHealth.GetComponent<RectTransform>().localScale.y);
		BarHunger.GetComponent<RectTransform>().localScale = new Vector3(CharacterHunger/100,BarHunger.GetComponent<RectTransform>().localScale.y);
		BarThirst.GetComponent<RectTransform>().localScale = new Vector3(CharacterThirst/100,BarThirst.GetComponent<RectTransform>().localScale.y);
		BarAdrenaline.GetComponent<RectTransform>().localScale = new Vector3(CharacterAdrenaline/100,BarAdrenaline.GetComponent<RectTransform>().localScale.y);
		BarBlood.GetComponent<RectTransform>().localScale = new Vector3(CharacterBlood/100,BarBlood.GetComponent<RectTransform>().localScale.y);
		BarSainity.GetComponent<RectTransform>().localScale = new Vector3(CharacterSainity/100,BarSainity.GetComponent<RectTransform>().localScale.y);
		BarEnergy.GetComponent<RectTransform>().localScale = new Vector3(CharacterEnergy/100,BarEnergy.GetComponent<RectTransform>().localScale.y);
		BarStamina.GetComponent<RectTransform>().localScale = new Vector3(BarEnergy.GetComponent<RectTransform>().localScale.x,-CharacterStamina/100);



		if (inventoryOn == true)
		{
			
			MainStatsUI.SetActive(true);
			InventoryUI.SetActive(true);
			BackpackUI.SetActive(true);
			UnReadyItemsUI.SetActive(true);
			WeaponSlotsUI.SetActive(true);


			if(ResetColided == true)
			{
				foreach (Transform child in ItemsInBackpack.transform)
				{
					child.gameObject.GetComponent<ItemCollisionDetection>().Colided = 0;
				}
				foreach (Transform child in UnReadyItemsUI.transform)
				{
					child.gameObject.GetComponent<ItemCollisionDetection>().Colided = 0;
				}
				ResetColided = false;
			}

            if (gameObject.GetComponent<MovementController>().CurrentStorage != null)
            {
                BackpackUI.transform.position = SafeBackpackUIPosition.transform.position;
                BackpackUI.gameObject.GetComponent<DragFreely>().StorageInteractionLock = true;
                StorageUI = gameObject.GetComponent<MovementController>().CurrentStorage.GetComponent<Storage>().MyStorageUI;
                StorageUI.transform.SetParent(SafeStorageUIPosition.transform);
                StorageUI.transform.position = SafeStorageUIPosition.transform.position;
            }
            else
            {
                StorageUI = null;
                BackpackUI.gameObject.GetComponent<DragFreely>().StorageInteractionLock = false;
            }

		}
		else
		{
			InventoryUI.SetActive(false);
			BackpackUI.SetActive(false);
			UnReadyItemsUI.SetActive(false);
			WeaponSlotsUI.SetActive(false);
			if(toggleMainStatsShow == true)
			{
				MainStatsUI.SetActive(true);
			}
			else
			{
				MainStatsUI.SetActive(false);
			}

			ResetColided = true;

            
        }

		//Bar limitations
		if(CharacterHealth > 100)
		{
			CharacterHealth = 100;
		}
		if(CharacterHealth < 0)
		{
			CharacterHealth = 0;
		}
		if(CharacterHunger > 100)
		{
			CharacterHunger = 100;
		}
		if(CharacterHunger < 0)
		{
			CharacterHunger = 0;
		}
		if(CharacterThirst > 100)
		{
			CharacterThirst = 100;
		}
		if(CharacterThirst < 0)
		{
			CharacterThirst = 0;
		}
		if(CharacterStamina > 100)
		{
			CharacterStamina = 100;
		}
		if(CharacterStamina < 0)
		{
			CharacterStamina = 0;
		}
		
		if (Input.GetKeyDown (KeyCode.Q)) 
		{
			toggleMainStatsShow = !toggleMainStatsShow;
		}
	}


}
