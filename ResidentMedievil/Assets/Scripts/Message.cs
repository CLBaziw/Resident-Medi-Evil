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
        public String TutorialTP;
        public String TutorialStart;
        public String Jump;
        public String Gun;
        
        public msgDisplay()
        {
            this.Welcome = "Welcome to Resident Medi-evil. Press W to move up, A to move left, S to move down, and D to move right.";
            this.TutorialTP = "Stand on this teleporter to complete the tutorial.";
            this.TutorialStart = "Welcome to the tutorial. Be careful of hostile enemies and objects. Use WASD to dodge incoming projectiles.";
            this.Jump = "Press the spacebar to jump over one square.";
            this.Gun = "Press 'J' to shoot your gun at the enemies!";
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
               
        msgBox.text = messageDisplay.nameTrigger;
    }

    //Clear message when player has left the trigger area
    public void OnTriggerExit2D(Collider2D collision)
    {
        msgBox.text = " ";
    }



}
