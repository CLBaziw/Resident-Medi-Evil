using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private string killer;
    private string collisionTag;
    // Start is called before the first frame update
    void Start()
    {
        killer = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.name == "Holes")
        {
            Debug.Log("You fell in a hole");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collisionTag = collision.gameObject.tag;

        switch (collisionTag)
        {
            case "Enemy":
            case "Enemy_Bullet":
            case "Hazard":
                killer = "enemy";
                break;
            case "Hole":
                killer = "hole";
                break;
        }

        if (killer != "")
        {
            //Kil player
            Debug.Log("Player died to " + killer);
        }
    }
}
