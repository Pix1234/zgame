using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemAction_StatsEditorItem : MonoBehaviour
{
    public GameObject Belonger;
    public enum WantedStat
    {
        Health,
        Hunger,
        Thirst,
        Adrenaline,
        Blood,
        Sanity,
        Energy
    }
    public float HowMuch;
    public float ConsumedProgress;
    public string ProcessName;
    //public ItemAction_StatsEditorItem.WantedStat WS;

    public List<ActionPerform.EachStat> AllStats = new List<ActionPerform.EachStat>();
    

    int itmID;


    void Start()
    {
        Belonger = gameObject.GetComponent<ItemFunctionFoundation>().blng;
        itmID = gameObject.GetComponent<ItemFunctionFoundation>().itmID;
    }
    void Update()
    {
        if (ConsumedProgress >= HowMuch)
        {
            Belonger.gameObject.GetComponent<ActionPerform>().Performing = false;
            Destroy(gameObject);
        }
    }
    public void CallProcess()
    {
        //Belonger.gameObject.GetComponent<ActionPerform>().ItemAction_ActionBullet = WS;
        //longer.gameObject.GetComponent<ActionPerform>().WantedStats.Add();
        Belonger.gameObject.GetComponent<ActionPerform>().StopAction();
        foreach (ActionPerform.EachStat ES in AllStats)
        {
            Debug.Log("Another");
            Belonger.gameObject.GetComponent<ActionPerform>().WantedStats.Add(ES);

        }

        Belonger.gameObject.GetComponent<ActionPerform>().ProcessName = ProcessName;
        Belonger.gameObject.GetComponent<ActionPerform>().CurrentActionBullet = "ItemAction_StatsEditorItem";
        Belonger.gameObject.GetComponent<ActionPerform>().ItemID = itmID;
        Belonger.gameObject.GetComponent<ActionPerform>().CurrentItem = gameObject;
        Belonger.gameObject.GetComponent<ActionPerform>().TimeToPerform = HowMuch;
        Belonger.gameObject.GetComponent<ActionPerform>().Progress = ConsumedProgress; 
        Belonger.gameObject.GetComponent<ActionPerform>().Performing = true;
    }
}
