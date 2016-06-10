using UnityEngine;
using System.Collections;

public class WeaponSlotController : MonoBehaviour
{
    public GameObject DropDown;
    public GameObject OppositeWeaponSlot;
    public GameObject Containing;
    public GameObject ContainingMag;
    public GameObject MyMagSlot;
    public GameObject Owner;

    

    void DropdownToggle()
    {
        DropDown.SetActive(!DropDown.activeInHierarchy);
    }

    void SwapWeapons()
    {
        if (Containing != null)
        {
            Containing.transform.parent = OppositeWeaponSlot.transform;

            if (ContainingMag != null)
            {
                ContainingMag.transform.parent = OppositeWeaponSlot.GetComponent<WeaponSlotController>().MyMagSlot.transform;
            }
        }
        if (OppositeWeaponSlot.GetComponent<WeaponSlotController>().Containing != null)
        {
            OppositeWeaponSlot.GetComponent<WeaponSlotController>().Containing.transform.parent = transform;

            if (OppositeWeaponSlot.GetComponent<WeaponSlotController>().ContainingMag != null)
            {
                OppositeWeaponSlot.GetComponent<WeaponSlotController>().ContainingMag.transform.parent = MyMagSlot.transform;
            }
        }
        
       
        // ContainingMag.transform.parent = OppositeWeaponSlot.transform;
        // OppositeWeaponSlot.GetComponent<WeaponSlotController>().ContainingMag.transform.parent = transform.parent;
    }

    void DropWeapon()
    {
        if (Containing != null)
        {
            Owner.GetComponent<Stats>().InstantiateWeaponPickup(Containing.GetComponent<WeaponSlotted>().WeaponID);
            GameObject.Destroy(Containing);
        }
        


        // ContainingMag.transform.parent = OppositeWeaponSlot.transform;
        // OppositeWeaponSlot.GetComponent<WeaponSlotController>().ContainingMag.transform.parent = transform.parent;
    }
}
