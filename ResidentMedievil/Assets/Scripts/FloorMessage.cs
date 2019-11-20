using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class FloorMessage : MonoBehaviour
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
}
