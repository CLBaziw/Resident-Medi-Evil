using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestsPowerUps : MonoBehaviour
{
    //Change sprite that is used
    public SpriteRenderer spriteRenderer;
    public Sprite openSprite, closedSprite;

    //Private variables
    private bool isOpen; //Check if chest as already been triggered
    private string chestName;

    //Power Up Trackers
    private bool audio = false;
    private bool jetPack = false;
    private bool speedUp = false;
    private bool lantern = false;
    private bool explosive = false;

    //Controllers
    private AudioSource audioController;

    // Start is called before the first frame update
    void Start()
    {
        chestName = GameObject.FindGameObjectWithTag("Chest").name;
        audioController = GameObject.Find("AudioController").GetComponent<AudioSource>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //When player collides with chest
    public void OnCollisionEnter2D(Collision2D player)
    {
        if (isOpen)
        {
            Debug.Log("Chest has already been triggered"); //If chest is open no more interacting
        }
        else
        {
            ChangeChest();

            Debug.Log(chestName);

            CheckPowerUp(chestName);            
        }
    }

    public void CheckPowerUp(string chestName)
    {
        //Check which power up was collected
        switch (chestName)
        {
            case "Audio":
                audio = true;
                playMusic();
                break;
            case "Jetpack":
                jetPack = true;
                break;
            case "SpeedUp":
                speedUp = true;
                break;
            case "Lantern":
                lantern = true;
                break;
            case "Explosive":
                explosive = true;
                break;
        }
    }

    //Makes chest not triggerable and changes appearance
    private void ChangeChest()
    {
        isOpen = true;
        spriteRenderer.sprite = openSprite;
    }

    private void playMusic()
    {
        audioController.Play();
    }
}