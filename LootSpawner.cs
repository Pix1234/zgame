using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LootSpawner : MonoBehaviour
{
    public GameObject FreeLootParent;
    public GameObject StorageLootParent;
    public GameObject Untaken;

    public GameObject ItemDB;

    public GameObject SPchar;
    public int ItemsCounter;
    public bool LootSpawned;


    public List<SpawnPoints> SpawnPointLists = new List<SpawnPoints>();

    [System.Serializable]
    public class SpawnPoints
    {
        public string Location;
        public Item.ItemSpawnPoint sp;
        public List<Loot> Rarities = new List<Loot>();

    }
    [System.Serializable]
    public class Loot
    {
        public string Name;
        public List<LootType> ItemTypes = new List<LootType>();

    }
    [System.Serializable]
    public class LootType
    {
        public string Name;
        public List<Item> ItemsList = new List<Item>();
    }

    
    void Start()
    {

        foreach (Item i in ItemDB.GetComponent<ItemDatabase>().items)
        {
            SpawnPointLists[CheckSpawnPoint(i)].Rarities[CheckRarity(i)].ItemTypes[CheckType(i)].ItemsList.Add(new Item(i.itemName, i.itemDesc, i.itemID, i.amountOfSlots, i.itemWeight, i.itemType, i.itemSpawnPoint, i.itemRarity, i.itemDragDropPrefab, i.itemPickupPrefab, i.cellSize, i.dragOffset));
            //List all items added//Debug.Log("("+i.itemID+") "+i.itemName + " is ready");
        }
        Invoke("SpawnLoot",0.1f);
    }
    int CheckSpawnPoint(Item GiveI)
    {
        if (GiveI.itemSpawnPoint == Item.ItemSpawnPoint.DestroyedVehicles)
        {
            return 1;
        }
        else if (GiveI.itemSpawnPoint == Item.ItemSpawnPoint.Houses)
        {
            return 2;
        }
        else if (GiveI.itemSpawnPoint == Item.ItemSpawnPoint.Industrial)
        {
            return 3;
        }
        else if (GiveI.itemSpawnPoint == Item.ItemSpawnPoint.Military)
        {
            return 4;
        }
        else if (GiveI.itemSpawnPoint == Item.ItemSpawnPoint.Trees)
        {
            return 5;
        }
        else
        {
            return 0;
        }
    }
    int CheckType(Item GiveI)
    {
        if (GiveI.itemType == Item.ItemOfType.Drink)
        {
            return 1;
        }
        else if (GiveI.itemType == Item.ItemOfType.CraftingMaterial)
        {
            return 2;
        }
        else if (GiveI.itemType == Item.ItemOfType.Placable)
        {
            return 3;
        }
        else
        {
            return 0;
        }
    }
    int CheckRarity(Item GiveI)
    {
        if (GiveI.itemRarity == Item.ItemRarity.Common)
        {
            return 1;
        }
        else if (GiveI.itemRarity == Item.ItemRarity.SlightlyCommon)
        {
            return 2;
        }
        else if (GiveI.itemRarity == Item.ItemRarity.Normal)
        {
            return 3;
        }
        else if (GiveI.itemRarity == Item.ItemRarity.Rare)
        {
            return 4;
        }
        else if (GiveI.itemRarity == Item.ItemRarity.VeryRare)
        {
            return 5;
        }
        else if (GiveI.itemRarity == Item.ItemRarity.ExtremelyRare)
        {
            return 6;
        }
        else if (GiveI.itemRarity == Item.ItemRarity.Legendary)
        {
            return 7;
        }
        else
        {
            return 0;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {

        }
    }
    int CheckRandomizedRarity(int rnd)
    {
        /*  0 399
            400 599
            600 749
            750 849
            850 909
            910 949
            950 974
            975 989
            990 1000*/
        if (rnd > 0 && rnd < 399)
        {
            return 8;
        }
        else if (rnd > 400 && rnd < 599)
        {
            return 0;
        }
        else if (rnd > 600 && rnd < 749)
        {
            return 1;
        }
        else if (rnd > 750 && rnd < 849)
        {
            return 2;
        }
        else if (rnd > 850 && rnd < 909)
        {
            return 3;
        }
        else if (rnd > 910 && rnd < 949)
        {
            return 4;
        }
        else if (rnd > 950 && rnd < 974)
        {
            return 5;
        }
        else if (rnd > 975 && rnd < 989)
        {
            return 6;
        }
        else
        {
            return 7;
        }
    }
    int GetLLType(LootInfo ll)
    {
        if (ll.Type == Item.ItemOfType.Drink)
        {
            return 1;
        }
        else if (ll.Type == Item.ItemOfType.CraftingMaterial)
        {
            return 2;
        }
        else if (ll.Type == Item.ItemOfType.Placable)
        {
            return 3;
        }
        else
        {
            return 0;
        }
    }
    int GetLLSpawnPoint(LootInfo ll)
    {

        if (ll.SpawnPoint == Item.ItemSpawnPoint.Houses)
        {
            return 1;
        }
        else if (ll.SpawnPoint == Item.ItemSpawnPoint.DestroyedVehicles)
        {
            return 2;
        }
        else if (ll.SpawnPoint == Item.ItemSpawnPoint.Military)
        {
            return 3;
        }
        else if (ll.SpawnPoint == Item.ItemSpawnPoint.Industrial)
        {
            return 4;
        }
        else
        {
            return 0;
        }
    }
    int GetSSType(Storage ss, int ind)
    {
        if (ss.AllSpawnpoints[ind].SpawnType == Item.ItemOfType.Drink)
        {
            return 1;
        }
        else if (ss.AllSpawnpoints[ind].SpawnType == Item.ItemOfType.CraftingMaterial)
        {
            return 2;
        }
        else if (ss.AllSpawnpoints[ind].SpawnType == Item.ItemOfType.Placable)
        {
            return 3;
        }
        else
        {
            return 0;
        }
    }
    int GetSSSpawnPoint(Storage ss,int ind)
    {

        if (ss.AllSpawnpoints[ind].Spawn == Item.ItemSpawnPoint.Houses)
        {
            return 1;
        }
        else if (ss.AllSpawnpoints[ind].Spawn == Item.ItemSpawnPoint.DestroyedVehicles)
        {
            return 2;
        }
        else if (ss.AllSpawnpoints[ind].Spawn == Item.ItemSpawnPoint.Military)
        {
            return 3;
        }
        else if (ss.AllSpawnpoints[ind].Spawn == Item.ItemSpawnPoint.Industrial)
        {
            return 4;
        }
        else
        {
            return 0;
        }
    }
    public void SpawnLoot()
    {
        foreach (Transform storageSpawnpoint in StorageLootParent.transform)
        {
            foreach (Transform UntakenDrag in storageSpawnpoint.GetComponent<Storage>().UnreadyItems.transform)
            {
                Destroy(UntakenDrag.gameObject);
            }
        }
        foreach (Transform UnTakenItem in Untaken.transform)
        {
            Destroy(UnTakenItem.gameObject);
        }
        foreach (Transform spawnpoint in FreeLootParent.transform)
        {
            LootInfo li = spawnpoint.gameObject.GetComponent<LootInfo>();
            int RandomizedRarity = CheckRandomizedRarity(Random.Range(0, 1000));
            if (RandomizedRarity != 8)
            {
                int RandomizedItem = Random.Range(0, SpawnPointLists[GetLLSpawnPoint(li)].Rarities[RandomizedRarity].ItemTypes[GetLLType(li)].ItemsList.Count);

                GameObject clone = Instantiate(SpawnPointLists[GetLLSpawnPoint(li)].Rarities[RandomizedRarity].ItemTypes[GetLLType(li)].ItemsList[RandomizedItem].itemPickupPrefab.gameObject, spawnpoint.transform.position, Quaternion.identity) as GameObject;
                clone.transform.parent = Untaken.transform;
            }
        }
        foreach (Transform storageSpawnpoint in StorageLootParent.transform)
        {
            foreach (Storage.StorageSpawnPoint storagePoint in storageSpawnpoint.gameObject.GetComponent<Storage>().AllSpawnpoints)
            {
                Storage ss = storageSpawnpoint.gameObject.GetComponent<Storage>();
                int RandomizedRarity = CheckRandomizedRarity(Random.Range(0, 1000));
                if (RandomizedRarity != 8)
                {
                    int pointIndex = storageSpawnpoint.gameObject.GetComponent<Storage>().AllSpawnpoints.IndexOf(storagePoint);
                    int RandomizedItem = Random.Range(0, SpawnPointLists[GetSSSpawnPoint(ss,pointIndex)].Rarities[RandomizedRarity].ItemTypes[GetSSType(ss,pointIndex)].ItemsList.Count);
                    
                    Debug.Log("Spawned");
                    GameObject clone = Instantiate(SpawnPointLists[GetSSSpawnPoint(ss,pointIndex)].Rarities[RandomizedRarity].ItemTypes[GetSSType(ss,pointIndex)].ItemsList[RandomizedItem].itemDragDropPrefab, storagePoint.Point.transform.position, Quaternion.identity) as GameObject;
                    clone.GetComponent<ItemCollisionDetection>().CollidingItem = false;
                    clone.GetComponent<ItemCollisionDetection>().CharCont = storageSpawnpoint.gameObject;
                    clone.GetComponent<ItemCollisionDetection>().itemDataBase = ItemDB;
                    clone.GetComponent<ItemCollisionDetection>().Inv = storageSpawnpoint.GetComponent<Storage>().UnreadyItems;
                    clone.transform.SetParent(storageSpawnpoint.GetComponent<Storage>().UnreadyItems.transform);
                    clone.GetComponent<ItemCollisionDetection>().posOffseter = new Vector3(ItemDB.GetComponent<ItemDatabase>().items[clone.GetComponent<ItemCollisionDetection>().itemID].cellSize.x, (-ItemDB.GetComponent<ItemDatabase>().items[clone.GetComponent<ItemCollisionDetection>().itemID].cellSize.y), 0);
                    clone.transform.position = storagePoint.Point.transform.position+ clone.gameObject.GetComponent<ItemCollisionDetection>().posOffseter;
                    clone.GetComponent<ItemCollisionDetection>().SlotOn = storagePoint.Point.gameObject;
                    clone.GetComponent<ItemCollisionDetection>().CollidingItem = false;
                    //
                    //
                    //clone.transform.parent = Untaken.transform;
                }
            }
        }
        LootSpawned = true;
    }
}
