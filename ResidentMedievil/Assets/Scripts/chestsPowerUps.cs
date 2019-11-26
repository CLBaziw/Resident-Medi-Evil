using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chestsPowerUps : MonoBehaviour
{
    //Change sprite that is used
    public SpriteRenderer spriteRenderer;
    public Sprite openSprite, closedSprite;

    //Private variables
    private bool isOpen; //Check if chest as already been triggered
    private GameController gController;
    private string chestName;

    // Start is called before the first frame update
    void Start()
    {
        chestName = GameObject.FindGameObjectWithTag("Chest").name;
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
            changeChest();

            //gController.checkPowerUp(chestName);            
        }
    }
    
    //Makes chest not triggerable and changes appearance
    private void changeChest()
    {
        isOpen = true;
        spriteRenderer.sprite = openSprite;
    }
}