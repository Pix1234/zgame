using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class NotificationSystem : MonoBehaviour
{
    [Header("Values")]
    public float FadeoutSpeed;
    
    [Header("References")]
    
    public GameObject TextPrefab;
    public GameObject Content;
    public GameObject NotificationUI;


    void Update()
    {
        JumpToBottom();
        NotificationsFade();
    }

    void SendNotification(string msg, Color col)
    {
        GameObject clone1 = (GameObject)Instantiate(TextPrefab, Content.transform.position, Quaternion.identity);
        JumpToBottom();
        NotificationsAlphaReset();

        clone1.transform.SetParent(Content.transform);
        clone1.GetComponent<Text>().color = col;
        clone1.GetComponent<Text>().text = msg;
        JumpToBottom();
    }

    void NotificationsAlphaReset()
    {
        
        foreach (Transform notification in Content.transform)
        {
            Color resetedCol = notification.GetComponent<Text>().color;
            resetedCol.a = 1;
            notification.GetComponent<Text>().color = resetedCol;
        }
    }
    void NotificationsFade()
    {
        //Debug.Log("Called fade");
        foreach (Transform notification in Content.transform)
        {
            Color fadedCol = notification.GetComponent<Text>().color;
            fadedCol.a -= 0.1f * Time.deltaTime * FadeoutSpeed;
            notification.GetComponent<Text>().color = fadedCol;
        }
    }

    void JumpToBottom()
    {
        NotificationUI.GetComponent<ScrollRect>().verticalScrollbar.gameObject.GetComponent<Scrollbar>().value = 0;
    }
}

