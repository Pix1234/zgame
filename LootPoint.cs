using UnityEngine;
using System.Collections;

[System.Serializable]
public class LootPoint
{
    public string dotName;
    public GameObject spawnInstance;


    public LootPoint(string name, GameObject sI)
    {
        dotName = name;
        spawnInstance = sI;
    }
    /*public string itemName;
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
        Placable
    }

    public enum ItemSpawnPoint
    {
        Industrial,
        Military,
        DestroyedVehicles,
        Houses,
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
    */
    /*public Item(string name,int id,int slotsAmount,string desc,float itemW,ItemOfType type, ItemSpawnPoint spawnPoint, ItemRarity itemRare, Transform PickupPre, Transform DnDPre, float cellX, float cellY, int offsetLeft, Vector3 dragOff, Vector3 placeOff)
	{
		itemName = name;
		itemID = id;
		slotsAmount = amountOfSlots;
		itemDesc = desc;
		itemIcon = Resources.Load<Texture2D>("Item Icons/"+name);
		itemWeight = itemW;
		itemCellSizeX = cellX;
		itemCellSizeY = cellY;
		itemLeftOffset = offsetLeft;
		itemType = type;
		itemSpawnPoint = spawnPoint;
		itemRarity = itemRare;
		dragOff = dragOffset;
		placeOff = placeOffset;

	}*/
    /*public Item()
	{
		itemID = -1;
	}*/
}
