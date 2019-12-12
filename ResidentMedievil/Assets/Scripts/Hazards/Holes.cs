using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holes : MonoBehaviour
{
    private GameController checkPowerUps;

    //Check for hit
    public LayerMask whatIsPlayer;
    public Transform topCheck;
    public Transform bottomCheck;
    private Vector2 size = new Vector2(1f, 0.7f);
    private bool topHit = false;
    private bool bottomHit = false;

    private GameObject player;

    private Death playerDeath;

    private void Start()
    {
        checkPowerUps = FindObjectOfType<GameController>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerDeath = FindObjectOfType<Death>();
    }

    private void Update()
    {
        if (!checkPowerUps.jetPack)
        {
            topHit = Physics2D.OverlapBox(topCheck.position, size, 0f, whatIsPlayer);
            bottomHit = Physics2D.OverlapBox(bottomCheck.position, size, 0f, whatIsPlayer);
        }

        if (topHit || bottomHit)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Player jumps over hole

                if (topHit)
                {
                    player.transform.position = new Vector2 (bottomCheck.position.x, bottomCheck.position.y - 0.4f);
                }
                else if (bottomHit)
                {
                    player.transform.position = new Vector2(topCheck.position.x, topCheck.position.y + 0.2f);
                }
                
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!checkPowerUps.jetPack)
            {
                playerDeath.KillPlayer("hole");
            }
            else
            {
                Collider2D collider2D = GetComponent<Collider2D>();

                collider2D.enabled = false;
            }
                  
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 10, 0, 0.5f);
        Gizmos.DrawCube(topCheck.position, size);
        Gizmos.DrawCube(bottomCheck.position, size);
    }
}
