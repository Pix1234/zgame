using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ConsoleController : MonoBehaviour
{
    public bool ConsoleOn;
    public GameObject TextPrefab;
    public GameObject Content;
    public GameObject ConsoleUI;
    public GameObject InputFieldUI;

    public GameObject LootSpawnerGameObject;

    public List<Command> ListOfCommands = new List<Command>();

    [System.Serializable]
    public class Command
    {
        public string CommandName;
        public string OutputMessage;
    }

    void Update ()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (Input.GetKeyDown(KeyCode.LeftAlt))
            {
                ConsoleOn = true;
            }
        }
        if (ConsoleOn == true)
        {
            ConsoleUI.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SendMessageToConsole(InputFieldUI.GetComponent<InputField>().text);
                InputFieldUI.GetComponent<InputField>().text = "";
                ConsoleUI.GetComponent<ScrollRect>().verticalScrollbar.gameObject.GetComponent<Scrollbar>().value = 0;
            }
            
        }
        else
        {
            ConsoleUI.SetActive(false);
        }
	}
    void SendMessageToConsole(string msg)
    {
        bool found = false;
        foreach (Command cmd in ListOfCommands)
        {
            if (cmd.CommandName == msg)
            {
                found = true;
                gameObject.SendMessage(msg);
                NewLine(" -" + msg);
                NewLine(" " + cmd.OutputMessage);
                break;
            }
        }
        if (found == false)
        {
            NewLine(" -" + msg);
            NewLine(" '"+msg+"' is an invalid command");
        }
    }
    
    void NewLine(string LineText)
    {
        GameObject clone1 = (GameObject)Instantiate(TextPrefab, Content.transform.position, Quaternion.identity);
        clone1.transform.parent = Content.transform;
        clone1.GetComponent<Text>().text = LineText;
        ConsoleUI.GetComponent<ScrollRect>().verticalScrollbar.gameObject.GetComponent<Scrollbar>().value = 0;
    }
    void DisableConsole()
    {
        ConsoleOn = false;
    }



    //Command functions

    void loot_respawn()
    {
        LootSpawnerGameObject.GetComponent<LootSpawner>().SpawnLoot();
    }
    void test_console()
    {

    }
}

