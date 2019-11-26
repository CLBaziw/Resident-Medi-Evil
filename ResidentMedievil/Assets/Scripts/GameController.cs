using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    

    private AudioSource song;

    // Start is called before the first frame update
    void Start()
    {
        song = GetComponent<AudioSource>();
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
}
