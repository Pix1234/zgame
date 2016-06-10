using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ActionPerform : MonoBehaviour
{


    //public string CurrentActionBullet;
    public string CurrentActionBullet;
    public string ProcessName;

    public bool Performing;

    public float Progress;
    public float TimeToPerform;

    public int ItemID;

    public GameObject ProgressBarUI;
    public GameObject ProgressTextUI;
    public GameObject ProgressGroupUI;

    //Item Action Variables
    public GameObject CurrentItem;

    //public ItemAction_StatsEditorItem.WantedStat ItemAction_ActionBullet;
    [System.Serializable]
    public class EachStat
    {
        public ItemAction_StatsEditorItem.WantedStat StatName;
        public float WantedAmount;

        public EachStat(ItemAction_StatsEditorItem.WantedStat wantstat, float wala)
        {
            StatName = wantstat;
            WantedAmount = wala;

        }

    }
    public List<EachStat> WantedStats = new List<EachStat>();

    

    void Update()
    {
        if (Performing == true)
        {
            DoingAction();

            if (Progress > TimeToPerform)
            {
                Progress = TimeToPerform;
            }
            else if (Progress < 0)
            {
                Progress = 0;
            }
            
            ProgressGroupUI.SetActive(true);
        }
        else
        {
            ProgressGroupUI.SetActive(false);
        }
        
    }
    void DoingAction()
    {
        /*switch (CurrentActionBullet)
        {
            case "ItemAction_StatsEditorItem":
                switch (ItemAction_ActionBullet)
                {
                    case ItemAction_StatsEditorItem.WantedStat.Health:
                        gameObject.GetComponent<Stats>().CharacterHealth += 1f * Time.deltaTime;
                        CurrentItem.GetComponent<ItemAction_StatsEditorItem>().ConsumedProgress = Progress;
                        break;
                    case ItemAction_StatsEditorItem.WantedStat.Hunger:
                        gameObject.GetComponent<Stats>().CharacterHunger += 1f * Time.deltaTime;
                        CurrentItem.GetComponent<ItemAction_StatsEditorItem>().ConsumedProgress = Progress;
                        break;
                    case ItemAction_StatsEditorItem.WantedStat.Thirst:
                        gameObject.GetComponent<Stats>().CharacterThirst += 1f * Time.deltaTime;
                        CurrentItem.GetComponent<ItemAction_StatsEditorItem>().ConsumedProgress = Progress;
                        break;
                    case ItemAction_StatsEditorItem.WantedStat.Adrenaline:
                        gameObject.GetComponent<Stats>().CharacterAdrenaline += 1f * Time.deltaTime;
                        CurrentItem.GetComponent<ItemAction_StatsEditorItem>().ConsumedProgress = Progress;
                        break;
                    case ItemAction_StatsEditorItem.WantedStat.Blood:
                        gameObject.GetComponent<Stats>().CharacterBlood += 1f * Time.deltaTime;
                        CurrentItem.GetComponent<ItemAction_StatsEditorItem>().ConsumedProgress = Progress;
                        break;
                    case ItemAction_StatsEditorItem.WantedStat.Sanity:
                        gameObject.GetComponent<Stats>().CharacterSanity += 1f * Time.deltaTime;
                        CurrentItem.GetComponent<ItemAction_StatsEditorItem>().ConsumedProgress = Progress;
                        break;
                    case ItemAction_StatsEditorItem.WantedStat.Energy:
                        gameObject.GetComponent<Stats>().CharacterEnergy += 1f * Time.deltaTime;
                        CurrentItem.GetComponent<ItemAction_StatsEditorItem>().ConsumedProgress = Progress;
                        break;
                }
                break;
        }*/
        //if()
        switch (CurrentActionBullet)
        {
            case "ItemAction_StatsEditorItem":
                CurrentItem.GetComponent<ItemAction_StatsEditorItem>().ConsumedProgress = Progress;
                ProgressTextUI.GetComponent<Text>().text = ProcessName + ": " + CurrentItem.gameObject.GetComponent<ItemCollisionDetection>().itemDataBase.GetComponent<ItemDatabase>().items[CurrentItem.GetComponent<ItemFunctionFoundation>().itmID].itemName;
                foreach (EachStat ES in WantedStats)
                {
                    switch (ES.StatName)
                    {
                        case ItemAction_StatsEditorItem.WantedStat.Health:
                            gameObject.GetComponent<Stats>().CharacterHealth += ES.WantedAmount * Time.deltaTime;
                            break;
                        case ItemAction_StatsEditorItem.WantedStat.Hunger:
                            gameObject.GetComponent<Stats>().CharacterHunger += ES.WantedAmount * Time.deltaTime;
                            break;
                        case ItemAction_StatsEditorItem.WantedStat.Thirst:
                            gameObject.GetComponent<Stats>().CharacterThirst += ES.WantedAmount * Time.deltaTime;
                            break;
                        case ItemAction_StatsEditorItem.WantedStat.Adrenaline:
                            gameObject.GetComponent<Stats>().CharacterAdrenaline += ES.WantedAmount * Time.deltaTime;
                            break;
                        case ItemAction_StatsEditorItem.WantedStat.Blood:
                            gameObject.GetComponent<Stats>().CharacterBlood += ES.WantedAmount * Time.deltaTime;
                            break;
                        case ItemAction_StatsEditorItem.WantedStat.Sanity:
                            gameObject.GetComponent<Stats>().CharacterSainity += ES.WantedAmount * Time.deltaTime;
                            break;
                        case ItemAction_StatsEditorItem.WantedStat.Energy:
                            gameObject.GetComponent<Stats>().CharacterEnergy += ES.WantedAmount * Time.deltaTime;
                            break;
                    }
                }
                break;
        }
        Progress += 1f * Time.deltaTime;
        ProgressBarUI.GetComponent<RectTransform>().localScale = new Vector3(Progress / TimeToPerform, ProgressBarUI.GetComponent<RectTransform>().localScale.y);
    }
    public void StopAction()
    {
        Performing = false;
        CurrentActionBullet = "";
        Progress = 0;
        TimeToPerform = 0;
        ItemID = 0;
        CurrentItem = null;
        ProcessName = "";
        WantedStats.Clear();
    }
}