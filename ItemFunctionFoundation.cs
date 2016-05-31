using UnityEngine;
using System.Collections;

public class ItemFunctionFoundation : MonoBehaviour 
{
	public GameObject blng;
	public int itmID;
	public int actionID;

	void Start () 
	{
		blng = transform.parent.GetComponent<InventoryBelonger> ().BelongsTo;
		itmID = gameObject.GetComponent<ItemCollisionDetection> ().itemID;
	}
	

	void Update () 
	{
		/*if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			SetStats(blng,"set","sainity",100);
		}
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			SetStats(blng,"decrease","thirst",30);
		}*/
	}
	void ButtonAction()
	{
        switch (itmID)
        {
            case 0:
                switch (actionID)
                {
                    case 0:
                        //EditStats(blng, "increase", "hunger", 70);
                        //Destroy(gameObject);
                        gameObject.GetComponent<ItemAction_StatsEditorItem>().CallProcess();
                        break;
                    case 1:
                        Debug.Log("Show info here");
                        break;
                    case 2:
                        blng.GetComponent<Stats>().InstantiatePickupItemConsumable(itmID,gameObject);
                        blng.GetComponent<ActionPerform>().StopAction();
                        Destroy(gameObject);
                        break;
                }
                break;
        }
        switch (itmID)
        {
            case 1:
                switch (actionID)
                {
                    case 0:
                        gameObject.GetComponent<ItemAction_StatsEditorItem>().CallProcess();
                        break;
                    case 1:
                        Debug.Log("Show info here");
                        break;
                    case 2:
                        blng.GetComponent<Stats>().InstantiatePickupItemConsumable(itmID,gameObject);
                        blng.GetComponent<ActionPerform>().StopAction();
                        Destroy(gameObject);
                        break;
                }
                break;
        }
        switch (itmID)
        {
            case 2:
                switch (actionID)
                {
                    case 0:
                        gameObject.GetComponent<ItemAction_StatsEditorItem>().CallProcess();
                        break;
                    case 1:
                        Debug.Log("Show info here");
                        break;
                    case 2:
                        blng.GetComponent<Stats>().InstantiatePickupItemConsumable(itmID,gameObject);
                        blng.GetComponent<ActionPerform>().StopAction();
                        Destroy(gameObject);
                        break;
                }
                break;
        }
        switch (itmID)
        {
            case 3:
                switch (actionID)
                {
                    case 0:
                        gameObject.GetComponent<ItemAction_StatsEditorItem>().CallProcess();
                        break;
                    case 1:
                        Debug.Log("Show info here");
                        break;
                    case 2:
                        
                        blng.GetComponent<Stats>().InstantiatePickupItemConsumable(itmID,gameObject);
                        blng.GetComponent<ActionPerform>().StopAction();
                        Destroy(gameObject);
                        break;
                }
                break;
        }
        switch (itmID)
        {
            case 4:
                switch (actionID)
                {
                    case 0:
                        gameObject.GetComponent<ItemAction_StatsEditorItem>().CallProcess();
                        break;
                    case 1:
                        Debug.Log("Show info here");
                        break;
                    case 2:
                        
                        blng.GetComponent<Stats>().InstantiatePickupItemConsumable(itmID,gameObject);
                        blng.GetComponent<ActionPerform>().StopAction();
                        Destroy(gameObject);
                        break;
                }
                break;
        }
        switch (itmID)
        {
            case 5:
                switch (actionID)
                {
                    case 0:
                        gameObject.GetComponent<ItemAction_StatsEditorItem>().CallProcess();
                        break;
                    case 1:
                        Debug.Log("Show info here");
                        break;
                    case 2:
                        
                        blng.GetComponent<Stats>().InstantiatePickupItemConsumable(itmID,gameObject);
                        blng.GetComponent<ActionPerform>().StopAction();
                        Destroy(gameObject);
                        break;
                }
                break;
        }
        switch (itmID)
        {
            case 6:
                switch (actionID)
                {
                    case 0:
                        gameObject.GetComponent<ItemAction_StatsEditorItem>().CallProcess();
                        break;
                    case 1:
                        Debug.Log("Show info here");
                        break;
                    case 2:
                        
                        blng.GetComponent<Stats>().InstantiatePickupItemConsumable(itmID,gameObject);
                        blng.GetComponent<ActionPerform>().StopAction();
                        Destroy(gameObject);
                        break;
                }
                break;
        }
        switch (itmID)
        {
            case 7:
                switch (actionID)
                {
                    case 0:
                        gameObject.GetComponent<ItemAction_StatsEditorItem>().CallProcess();
                        break;
                    case 1:
                        Debug.Log("Show info here");
                        break;
                    case 2:
                        
                        blng.GetComponent<Stats>().InstantiatePickupItemConsumable(itmID,gameObject);
                        blng.GetComponent<ActionPerform>().StopAction();
                        Destroy(gameObject);
                        break;
                }
                break;
        }
        switch (itmID)
        {
            case 8:
                switch (actionID)
                {
                    case 0:
                        gameObject.GetComponent<ItemAction_StatsEditorItem>().CallProcess();
                        break;
                    case 1:
                        Debug.Log("Show info here");
                        break;
                    case 2:
                        blng.GetComponent<Stats>().InstantiatePickupItemConsumable(itmID,gameObject);
                        blng.GetComponent<ActionPerform>().StopAction();
                        Destroy(gameObject);
                        break;
                }
                break;
        }
        switch (itmID)
        {
            case 9:
                switch (actionID)
                {
                    case 0:
                        gameObject.GetComponent<ItemAction_StatsEditorItem>().CallProcess();
                        break;
                    case 1:
                        Debug.Log("Show info here");
                        break;
                    case 2:
                        
                        blng.GetComponent<Stats>().InstantiatePickupItemConsumable(itmID,gameObject);
                        blng.GetComponent<ActionPerform>().StopAction();
                        Destroy(gameObject);
                        break;
                }
                break;
        }
        switch (itmID)
        {
            case 10:
                switch (actionID)
                {
                    case 0:
                        gameObject.GetComponent<ItemAction_StatsEditorItem>().CallProcess();
                        break;
                    case 1:
                        Debug.Log("Show info here");
                        break;
                    case 2:
                        
                        blng.GetComponent<Stats>().InstantiatePickupItemConsumable(itmID,gameObject);
                        blng.GetComponent<ActionPerform>().StopAction();
                        Destroy(gameObject);
                        break;
                }
                break;
        }
        switch (itmID)
        {
            case 11:
                switch (actionID)
                {
                    case 0:
                        gameObject.GetComponent<ItemAction_StatsEditorItem>().CallProcess();
                        break;
                    case 1:
                        Debug.Log("Show info here");
                        break;
                    case 2:
                        
                        blng.GetComponent<Stats>().InstantiatePickupItemConsumable(itmID,gameObject);
                        blng.GetComponent<ActionPerform>().StopAction();
                        Destroy(gameObject);
                        break;
                }
                break;
        }
        switch (itmID)
        {
            case 12:
                switch (actionID)
                {
                    case 0:
                        gameObject.GetComponent<ItemAction_StatsEditorItem>().CallProcess();
                        break;
                    case 1:
                        Debug.Log("Show info here");
                        break;
                    case 2:
                        
                        blng.GetComponent<Stats>().InstantiatePickupItemConsumable(itmID,gameObject);
                        blng.GetComponent<ActionPerform>().StopAction();
                        Destroy(gameObject);
                        break;
                }
                break;
        }
        switch (itmID)
        {
            case 13:
                switch (actionID)
                {
                    case 0:
                        gameObject.GetComponent<ItemAction_StatsEditorItem>().CallProcess();
                        break;
                    case 1:
                        Debug.Log("Show info here");
                        break;
                    case 2:
                        
                        blng.GetComponent<Stats>().InstantiatePickupItemConsumable(itmID,gameObject);
                        blng.GetComponent<ActionPerform>().StopAction();
                        Destroy(gameObject);
                        break;
                }
                break;
        }
        switch (itmID)
        {
            case 14:
                switch (actionID)
                {
                    case 0:
                        gameObject.GetComponent<ItemAction_StatsEditorItem>().CallProcess();
                        break;
                    case 1:
                        Debug.Log("Show info here");
                        break;
                    case 2:
                        
                        blng.GetComponent<Stats>().InstantiatePickupItemConsumable(itmID,gameObject);
                        blng.GetComponent<ActionPerform>().StopAction();
                        Destroy(gameObject);
                        break;
                }
                break;
        }
        switch (itmID)
        {
            case 15:
                switch (actionID)
                {
                    case 0:
                        gameObject.GetComponent<ItemAction_StatsEditorItem>().CallProcess();
                        break;
                    case 1:
                        Debug.Log("Show info here");
                        break;
                    case 2:
                        
                        blng.GetComponent<Stats>().InstantiatePickupItemConsumable(itmID,gameObject);
                        blng.GetComponent<ActionPerform>().StopAction();
                        Destroy(gameObject);
                        break;
                }
                break;
        }
        switch (itmID)
        {
            case 16:
                switch (actionID)
                {
                    
                    case 1:
                        Debug.Log("Show info here");
                        break;
                    case 2:

                        blng.GetComponent<Stats>().InstantiatePickupItemAmmo(itmID, gameObject);
                        blng.GetComponent<ActionPerform>().StopAction();
                        Destroy(gameObject);
                        break;
                }
                break;
        }
    }
	public void EditStats(GameObject belonger,string method,string statName,int amount)
	{
		// Available methods: increase, increase by time, decrease, decrease by time, set
		// Available stat names: health, hunger, thirst, adrenaline, blood, sainity, energy
		switch (method) 
		{
		case "increase":
			switch (statName) 
			{
			case "health":
				belonger.GetComponent<Stats> ().CharacterHealth += amount;
				break;
			case "hunger":
				belonger.GetComponent<Stats> ().CharacterHunger += amount;
				break;
			case "thirst":
				belonger.GetComponent<Stats> ().CharacterThirst += amount;
				break;
			case "adrenaline":
				belonger.GetComponent<Stats> ().CharacterAdrenaline += amount;
				break;
			case "blood":
				belonger.GetComponent<Stats> ().CharacterBlood += amount;
				break;
			case "sainity":
				belonger.GetComponent<Stats> ().CharacterSainity += amount;
				break;
			case "energy":
				belonger.GetComponent<Stats> ().CharacterEnergy += amount;
				break;
			}
			break;
		case "increase by time":
			switch (statName) 
			{
			case "health":
				belonger.GetComponent<Stats> ().CharacterHealth += amount*Time.deltaTime;
				break;
			case "hunger":
				belonger.GetComponent<Stats> ().CharacterHunger += amount*Time.deltaTime;
				break;
			case "thirst":
				belonger.GetComponent<Stats> ().CharacterThirst += amount*Time.deltaTime;
				break;
			case "adrenaline":
				belonger.GetComponent<Stats> ().CharacterAdrenaline += amount*Time.deltaTime;
				break;
			case "blood":
				belonger.GetComponent<Stats> ().CharacterBlood += amount*Time.deltaTime;
				break;
			case "sainity":
				belonger.GetComponent<Stats> ().CharacterSainity += amount*Time.deltaTime;
				break;
			case "energy":
				belonger.GetComponent<Stats> ().CharacterEnergy += amount*Time.deltaTime;
				break;
			}
			break;
		case "decrease":
			switch (statName) 
			{
			case "health":
				belonger.GetComponent<Stats> ().CharacterHealth -= amount;
				break;
			case "hunger":
				belonger.GetComponent<Stats> ().CharacterHunger -= amount;
				break;
			case "thirst":
				belonger.GetComponent<Stats> ().CharacterThirst -= amount;
				break;
			case "adrenaline":
				belonger.GetComponent<Stats> ().CharacterAdrenaline -= amount;
				break;
			case "blood":
				belonger.GetComponent<Stats> ().CharacterBlood -= amount;
				break;
			case "sainity":
				belonger.GetComponent<Stats> ().CharacterSainity -= amount;
				break;
			case "energy":
				belonger.GetComponent<Stats> ().CharacterEnergy -= amount;
				break;
			}
			break;
		case "decrease by time":
			switch (statName) 
			{
			case "health":
				belonger.GetComponent<Stats> ().CharacterHealth -= amount*Time.deltaTime;
				break;
			case "hunger":
				belonger.GetComponent<Stats> ().CharacterHunger -= amount*Time.deltaTime;
				break;
			case "thirst":
				belonger.GetComponent<Stats> ().CharacterThirst -= amount*Time.deltaTime;
				break;
			case "adrenaline":
				belonger.GetComponent<Stats> ().CharacterAdrenaline -= amount*Time.deltaTime;
				break;
			case "blood":
				belonger.GetComponent<Stats> ().CharacterBlood -= amount*Time.deltaTime;
				break;
			case "sainity":
				belonger.GetComponent<Stats> ().CharacterSainity -= amount*Time.deltaTime;
				break;
			case "energy":
				belonger.GetComponent<Stats> ().CharacterEnergy -= amount*Time.deltaTime;
				break;
			}
			break;
		case "set":
			switch (statName) 
			{
			case "health":
				belonger.GetComponent<Stats> ().CharacterHealth = amount;
				break;
			case "hunger":
				belonger.GetComponent<Stats> ().CharacterHunger = amount;
				break;
			case "thirst":
				belonger.GetComponent<Stats> ().CharacterThirst = amount;
				break;
			case "adrenaline":
				belonger.GetComponent<Stats> ().CharacterAdrenaline = amount;
				break;
			case "blood":
				belonger.GetComponent<Stats> ().CharacterBlood = amount;
				break;
			case "sainity":
				belonger.GetComponent<Stats> ().CharacterSainity = amount;
				break;
			case "energy":
				belonger.GetComponent<Stats> ().CharacterEnergy = amount;
				break;
			}
			break;
		}

	}

}
