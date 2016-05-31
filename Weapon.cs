using UnityEngine;
using System.Collections;

[System.Serializable]
public class Weapon
{
    public string weaponName;
    public string weaponDesc;
    public int weaponID;
    public int weaponAimFieldOfView;
    public float weaponWeight;
    public WeaponOfType weaponType;
    public Item.ItemSpawnPoint weaponSpawnPoint;
    public Item.ItemRarity weaponRarity;
    public GameObject weaponDragDropPrefab;
    public GameObject weaponPickupPrefab;
    public Vector2 dragOffset;
    public Vector2 sizeInSlot;

    public enum WeaponOfType
    {
        Melee,
        SMG,
        Pistol,
        Rifle,
        Sniper
    }
    

    public Weapon(string NameOfItem,
                string DescriptionOfItem,
                int ItemID,
                int ItemAimFieldOfView,
                float WeightOfItem,
                WeaponOfType TypeOfItem,
                Item.ItemSpawnPoint SpawnPointOfItem,
                Item.ItemRarity RarityOfItem,
                GameObject DragDropPrefabOfItem,
                GameObject PickupPrefabOfItem,
                Vector2 DragOffsetOfItem)
    {
        weaponName = NameOfItem;
        weaponDesc = DescriptionOfItem;
        weaponID = ItemID;
        weaponAimFieldOfView = ItemAimFieldOfView;
        weaponWeight = WeightOfItem;
        weaponType = TypeOfItem;
        weaponSpawnPoint = SpawnPointOfItem;
        weaponRarity = RarityOfItem;
        weaponDragDropPrefab = DragDropPrefabOfItem;
        weaponPickupPrefab = PickupPrefabOfItem;
        dragOffset = DragOffsetOfItem;

    }
}
