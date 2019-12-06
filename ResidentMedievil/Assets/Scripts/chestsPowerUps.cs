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
    public bool audioOn = false;
    public bool jetPack = false;
    public bool speedUp = false;
    public bool lantern = false;
    public bool explosive = false;

    //Controllers
    private AudioSource audioController;
    private PlayerMovement playerMovement;
    private MessageDisplay messageDisplay;
    private GameObject fogOfWar;

    // Start is called before the first frame update
    void Start()
    {
        
        audioController = GameObject.Find("GameController").GetComponent<AudioSource>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        messageDisplay = FindObjectOfType<MessageDisplay>();
        fogOfWar = GameObject.Find("FogOfWar");
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

            chestName = gameObject.name;

            Debug.Log(chestName);

            CheckPowerUp(chestName);

            messageDisplay.chestDisplay(chestName);
        }
    }

    private void CheckPowerUp(string chestName)
    {
        //Check which power up was collected
        switch (chestName)
        {
            case "Audio":
                audioOn = true;
                playMusic();
                break;
            case "Jetpack":
                jetPack = true;
                Debug.Log("Jetpack has been picked up"); //Implement double jump
                break;
            case "SpeedUp":
                speedUp = true;
                increaseSpeed();
                break;
            case "Lantern":
                lantern = true;
                FogOfWar();
                break;
            case "Explosive":
                explosive = true;
                Debug.Log("Explosive rounds have been picked up"); //Implement explosive rounds
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

    private void increaseSpeed()
    {
        playerMovement.moveSpeed = 2 * playerMovement.moveSpeed; //Double player movement speed
    }

    private void FogOfWar()
    {
        Destroy(fogOfWar);
    }
}