using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teleporter : MonoBehaviour
{
    private GameObject waypoint;

    //Display to message box
    private Text msgBox;

    // Start is called before the first frame update
    void Start()
    {
        waypoint = gameObject.transform.GetChild(0).gameObject;
        msgBox = GameObject.Find("Message").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.position = waypoint.transform.position;

            //When player steps on teleporter, clear Message box
            msgBox.text = "";
        }
    }
}
