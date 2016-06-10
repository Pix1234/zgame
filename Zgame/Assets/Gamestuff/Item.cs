using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item
{
	public string itemName;
	public string itemDesc;
	public int itemID;
	public int amountOfSlots;
	public float itemWeight;
	public ItemOfType itemType;
	public ItemSpawnPoint itemSpawnPoint;
	public ItemRarity itemRarity;
	public GameObject itemDragDropPrefab;
	public GameObject itemPickupPrefab;
	public Vector2 cellSize;
	public Vector2 dragOffset;

	public enum ItemOfType
	{
		Food,
		Drink,
		CraftingMaterial,
		placeable
	}

	public enum ItemSpawnPoint
	{
		Industrial,
		Military,
		DestroyedVehicles,
		Houses,
        Trees,
		TestingRoom
	}

	public enum ItemRarity
	{
		VeryCommon,
		Common,
		SlightlyCommon,
		Normal,
		Rare,
		VeryRare,
		ExtremelyRare,
		Legendary
	}

	public Item(string NameOfItem, 
                string DescriptionOfItem,
                int ItemID,
                int SlotsAmount,
                float WeightOfItem,
                ItemOfType TypeOfItem,
                ItemSpawnPoint SpawnPointOfItem,
                ItemRarity RarityOfItem,
                GameObject DragDropPrefabOfItem,
                GameObject PickupPrefabOfItem,
                Vector2 CellSizeOfItem,
                Vector2 DragOffsetOfItem)
	{
		itemName = NameOfItem;
        itemDesc = DescriptionOfItem;
        itemID = ItemID;
        amountOfSlots = SlotsAmount;
        itemWeight = WeightOfItem;
        itemType = TypeOfItem;
        itemSpawnPoint = SpawnPointOfItem;
        itemRarity = RarityOfItem;
        itemDragDropPrefab = DragDropPrefabOfItem;
        itemPickupPrefab = PickupPrefabOfItem;
        cellSize = CellSizeOfItem;
        dragOffset = DragOffsetOfItem;

    }
	/*public Item()
	{
		itemID = -1;
	}*/
}
