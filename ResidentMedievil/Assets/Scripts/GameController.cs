using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //Power Ups
    private bool audio = false;
    private bool jetPack = false;
    private bool speedUp = false;
    private bool lantern = false;
    private bool explosive = false; 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Quit the game - THIS NEEDS TO BE CHANGED TO A MENU
            Application.Quit();
        }
    }

    public void checkPowerUp(string chestName)
    {
        //Check which power up was collected
        switch (chestName)
        {
            case "Audio":
                audio = true;
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
}
