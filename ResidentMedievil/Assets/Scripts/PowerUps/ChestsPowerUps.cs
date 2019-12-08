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

    //Controllers
    private AudioSource audioController;
    private PlayerMovement playerMovement;
    private MessageDisplay messageDisplay;
    private GameController tracker;

    // Start is called before the first frame update
    void Start()
    {
        audioController = GameObject.Find("GameController").GetComponent<AudioSource>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        messageDisplay = FindObjectOfType<MessageDisplay>();
        tracker = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //When player collides with chest
    public void OnCollisionEnter2D(Collision2D player)
    {
        if (player.gameObject.CompareTag("Player")){
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
    }

    private void CheckPowerUp(string chestName)
    {
        //Check which power up was collected
        switch (chestName)
        {
            case "Audio":
                tracker.audioOn = true;
                PlayMusic();
                break;
            case "Jetpack":
                tracker.jetPack = true;
                break;
            case "SpeedUp":
                tracker.speedUp = true;
                IncreaseSpeed();
                break;
            case "Lantern":
                tracker.lantern = true;
                FogOfWar();
                break;
            case "Explosive":
                tracker.explosive = true;
                break;
        }
    }

    //Makes chest not triggerable and changes appearance
    private void ChangeChest()
    {
        isOpen = true;
        spriteRenderer.sprite = openSprite;
    }

    private void PlayMusic()
    {
        audioController.Play();
    }

    private void IncreaseSpeed()
    {
        playerMovement.moveSpeed = 2 * playerMovement.moveSpeed; //Double player movement speed
    }

    private void FogOfWar()
    {
        Destroy(GameObject.Find("FogOfWar"));
    }
}