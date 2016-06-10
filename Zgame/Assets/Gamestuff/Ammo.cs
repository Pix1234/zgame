using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Ammo
{
    public string ammoName;
    public string ammoDesc;
    public int ammoID;
    public float ammoWeight;
    public Item.ItemSpawnPoint weaponSpawnPoint;
    public Item.ItemRarity weaponRarity;
    public GameObject ammoDragDropPrefab;
    public GameObject ammoPlacedPrefab;
    public GameObject ammoPickupPrefab;
    public Vector2 dragOffset;
    public Vector2 sizeInSlot;
    public List<int> SupportedWeaponID = new List<int>();

    public Ammo(string NameOfItem,
                string DescriptionOfItem,
                int ItemID,
                float WeightOfItem,
                Item.ItemSpawnPoint SpawnPointOfItem,
                Item.ItemRarity RarityOfItem,
                GameObject DragDropPrefabOfItem,
                GameObject PlacedPrefabOfItem,
                GameObject PickupPrefabOfItem,
                Vector2 DragOffsetOfItem)
    {
        ammoName = NameOfItem;
        ammoDesc = DescriptionOfItem;
        ammoID = ItemID;
        ammoWeight = WeightOfItem;
        weaponSpawnPoint = SpawnPointOfItem;
        weaponRarity = RarityOfItem;
        ammoDragDropPrefab = DragDropPrefabOfItem;
        ammoPlacedPrefab = PlacedPrefabOfItem;
        ammoPickupPrefab = PickupPrefabOfItem;
        dragOffset = DragOffsetOfItem;

    }
}
