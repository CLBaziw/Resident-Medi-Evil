using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUps : MonoBehaviour
{
    //Power Ups
    //public bool Audio = false;

    public SpriteRenderer spriteRenderer;

    public Sprite openSprite, closedSprite;

    private bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D player)
    {
        if (isOpen)
        {
            Debug.Log("Stop"); //If chest is open no more interacting
        }
        else
        {
            changeChest();

            //Write switch statement to check which powerup it is
        }
    }
    
    private void changeChest()
    {
        isOpen = true;
        spriteRenderer.sprite = openSprite;
    }
}