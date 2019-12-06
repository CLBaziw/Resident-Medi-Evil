using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakWalls : MonoBehaviour
{
    private GameController tracker;

    public GameObject explosionObj;

    public Animation animation;

    private void Start()
    {
        tracker = FindObjectOfType<GameController>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet")) { 
            if (tracker.explosive)
            {
                //Play explosion animation

                Destroy(gameObject);
                
            }
        }
    }
}
