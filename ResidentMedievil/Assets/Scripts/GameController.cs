using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //Power Up Trackers
    public bool audioOn = false;
    public bool jetPack = false;
    public bool speedUp = false;
    public bool lantern = false;
    public bool explosive = false;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Esc key has been pressed");
            
            //Bring up menu
        }
    }
}
