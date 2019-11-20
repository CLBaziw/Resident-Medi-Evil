using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Message : MonoBehaviour
{
    private class msgDisplay
    {
        public String Welcome;
        public String Tutorial;
        public msgDisplay()
        {
            this.Welcome = "Welcome to Resident Medi-evil. Press W to move up, A to move left, S to move down, and D to move right.";
            this.Tutorial = "Stand on this teleporter to complete the tutorial.";
        }
    }

    //Private variables
    private Text msgBox;

    public void Awake()
    {
        msgBox = GameObject.Find("Message").GetComponent<Text>();
    }
    
    //When trigger is activated
    public void OnTriggerEnter2D(Collider2D collision)
    {
        var messageDisplay = new msgDisplay();
        //Get name of trigger to use to call different methods
        var nameTrigger = gameObject.name;

        Debug.Log(nameTrigger);
               
        msgBox.text = messageDisplay.Welcome;
    }

    //Clear message when player has left the trigger area
    public void OnTriggerExit2D(Collider2D collision)
    {
        msgBox.text = " ";
    }



}
