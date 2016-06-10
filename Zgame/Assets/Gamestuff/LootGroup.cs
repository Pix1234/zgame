using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LootGroup : MonoBehaviour
{
    public List<LootPoint> lootList = new List<LootPoint>();

    void Start()
    {
        foreach (Transform child in gameObject.transform)
        {
            lootList.Add(new LootPoint(child.name, child.gameObject));
        }

        
    }
}
