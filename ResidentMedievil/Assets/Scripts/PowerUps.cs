using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUps : MonoBehaviour
{
    private GameObject openChest;

    //Power Ups
    public bool Audio = false;

    // Start is called before the first frame update
    void Start()
    {
        openChest = GameObject.Find("Open_Chest");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D powerup)
    {
        Debug.Log("Chest triggered");

        if (powerup.gameObject.name == "Audio")
        {
            Audio = true;
        }
    }

    /*
    private void changeChest(Collider2D powerup)
    {
        powerup.gameObject.SetActive(false); //Get rid of triggerable chest (closed chest)

        openChest.enabled = false;

    }
    */
}
