using UnityEngine;
using System.Collections;

public class StorageDistanceDetection : MonoBehaviour
{
    public bool Detected;
    public GameObject Belonger;

    public enum StorageType
    {
        Backpack,
        Storage
    }
    public StorageType TypeOfStorage;

    void Update()
    {
        switch (TypeOfStorage)
        {
            case StorageType.Backpack:
                if (Belonger.GetComponent<Stats>().inventoryOn == false)
                {
                    Detected = false;
                }
                break;
            case StorageType.Storage:
                if (Belonger.GetComponent<Storage>().CurrentlyBeingUsed == false)
                {
                    Detected = false;
                }
                break;
        }
    }

    void OnCollisionStay2D(Collision2D coll)
    {

        if (coll.gameObject.tag == "StorageUI")
        {
            if (coll.gameObject.transform.parent == transform.parent)
            {
                Detected = true;
            }
        }
        
    }
    void OnCollisionExit2D(Collision2D coll)
    {

        if (coll.gameObject.tag == "StorageUI")
        {
            Detected = false;
        }


        
    }
}
