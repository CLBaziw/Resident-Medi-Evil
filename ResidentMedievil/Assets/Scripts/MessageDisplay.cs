using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MessageDisplay : MonoBehaviour
{
    private Text msgBox;

    public void Awake()
    {
        //Get message box to print to
        msgBox = GameObject.Find("Message").GetComponent<Text>();
    }
    
    //When trigger is activated
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Get contents of Tilemap Trigger text component
        Text message = GetComponent<Text>();

        msgBox.text = message.text;       
    }

    //Clear message when player has left the trigger area
    public void OnTriggerExit2D(Collider2D collision)
    {
        msgBox.text = " ";
    }

    
    public void chestDisplay(string chestName)
    {
        //Get text adttached to chest
        Text chestMessage = GameObject.Find(chestName).GetComponent<Text>(); 

        //Display text
        msgBox.text = chestMessage.text;

        //Turn off text 
        chestDisplayOff(chestName);
    }
    
    public void chestDisplayOff(string chestName)
    {
        Debug.Log("Turn off chest display");
        if (chestName == "Jetpack")
        {
            //wait for double jump input to clear message box
        }
        else if (chestName == "Explosive")
        {
            //wait for J key to clear message box
        }
        //Chests will also be turned off when teleporter is triggered and player moves to new room.
    }
}
