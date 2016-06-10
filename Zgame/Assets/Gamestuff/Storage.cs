using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Storage : MonoBehaviour
{
    public string StorageName;
    public GameObject MyStorageUI;
    public GameObject ItemsInStorage;
    public GameObject StorageTextUI;
    public GameObject UnreadyItems;
    public GameObject currentlyInteractingInstance;
    public GameObject LootSpawnerRef;
    public GameObject ItemDropper;
    public bool CurrentlyBeingUsed;
    public bool ResetColided;
    public bool Looted;
    public float DropForce;

    public List<StorageSpawnPoint> AllSpawnpoints = new List<StorageSpawnPoint>();

    public Item.ItemSpawnPoint SpawnPoint;
    public Item.ItemOfType Type;

    [System.Serializable]
    public class StorageSpawnPoint
    {
        public GameObject Point;
        public Item.ItemSpawnPoint Spawn;
        public Item.ItemOfType SpawnType;

    }



    void Start ()
    {
        StorageTextUI.GetComponent<Text>().text = StorageName;
	}
	
	

	void Update ()
    {
        if (CurrentlyBeingUsed == true)
        {
            Looted = true;
        }
        if (CurrentlyBeingUsed == true)
        {
            foreach (Transform go in UnreadyItems.transform)
            {
                go.GetComponent<BoxCollider2D>().isTrigger = false;
            }
        }
        else
        {
            foreach (Transform go in UnreadyItems.transform)
            {
                go.GetComponent<BoxCollider2D>().isTrigger = true;
                go.GetComponent<ItemCollisionDetection>().CollidingItem = false;
            }
        }
        
        
        
        if (LootSpawnerRef.GetComponent<LootSpawner>().LootSpawned == true)
        {
            MyStorageUI.SetActive(CurrentlyBeingUsed);
        }
        else
        {
            MyStorageUI.SetActive(true);
        }
        if (CurrentlyBeingUsed == true)
        {
            if (ResetColided == true)
            {
                foreach (Transform child in ItemsInStorage.transform)
                {
                    child.gameObject.GetComponent<ItemCollisionDetection>().Colided = 0;
                }
                ResetColided = false;
            }
        }
        else
        {
            ResetColided = true;
        }

        
    }
}
