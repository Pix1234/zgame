using UnityEngine;
using System.Collections;

public class WeaponsManager : MonoBehaviour
{
    public GameObject AllBacked;
    public GameObject AllHanded;
    public bool BigWeapons;
	
	void Update ()
    {
        //Check if current state is actually holding a gun, then enable the weapon object
        //check state not bool, but keep setting bool to true
        if (gameObject.GetComponent<Stats>().HandsUI.GetComponent<WeaponSlotController>().Containing != null)
        {
            gameObject.GetComponent<MovementController>().animator.SetLayerWeight(2, 1f);
            foreach (Transform HandedWpn in AllHanded.transform)
            {
                if (HandedWpn.GetComponent<WeaponSetup_Hands>().ThisWeaponsID == gameObject.GetComponent<Stats>().HandsUI.GetComponent<WeaponSlotController>().Containing.GetComponent<WeaponSlotted>().WeaponID)
                {
                    HandedWpn.gameObject.SetActive(true);
                    BigWeapons = true;
                    
                }
                else
                {
                    HandedWpn.gameObject.SetActive(false);
                    BigWeapons = false;
                }

            }
        }
        else
        {
            foreach (Transform HandedWpn in AllHanded.transform)
            {
                HandedWpn.gameObject.SetActive(false);
                

            }
            gameObject.GetComponent<MovementController>().animator.SetLayerWeight(2, 0f);
            BigWeapons = false;
        }
        if (gameObject.GetComponent<Stats>().BackUI.GetComponent<WeaponSlotController>().Containing != null)
        {
            foreach (Transform BackedWpn in AllBacked.transform)
            {
                if (BackedWpn.GetComponent<WeaponSetup_Back>().ThisWeaponsID == gameObject.GetComponent<Stats>().BackUI.GetComponent<WeaponSlotController>().Containing.GetComponent<WeaponSlotted>().WeaponID)
                {
                    BackedWpn.gameObject.SetActive(true);
                }
                else
                {
                    BackedWpn.gameObject.SetActive(false);
                }

            }

        }
        else
        {
            foreach (Transform BackedWpn in AllBacked.transform)
            {
                BackedWpn.gameObject.SetActive(false);

            }
        }

    }

    public bool CheckIfHoldingWeapon()
    {
        if (gameObject.GetComponent<Stats>().HandsUI.GetComponent<WeaponSlotController>().Containing != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    public GameObject GetInHandsWeaponObject()
    {
        foreach (Transform HandedWpn in AllHanded.transform)
        {
            if (HandedWpn.GetComponent<WeaponSetup_Hands>().ThisWeaponsID == gameObject.GetComponent<Stats>().HandsUI.GetComponent<WeaponSlotController>().Containing.GetComponent<WeaponSlotted>().WeaponID)
            {
                return HandedWpn.gameObject;
            }
        }
        return null;
    }
    public int GetInHandsWeaponID()
    {
        foreach (Transform HandedWpn in AllHanded.transform)
        {
            if (HandedWpn.GetComponent<WeaponSetup_Hands>().ThisWeaponsID == gameObject.GetComponent<Stats>().HandsUI.GetComponent<WeaponSlotController>().Containing.GetComponent<WeaponSlotted>().WeaponID)
            {
                return HandedWpn.gameObject.GetComponent<WeaponSetup_Hands>().ThisWeaponsID;
            }
        }
        return 0;
    }

}
