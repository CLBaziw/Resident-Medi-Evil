﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZOMBIE : MonoBehaviour
{
    private float latestDirectionChangeTime;
    private readonly float directionChangeTime = 0.5f;
    private float characterVelocity = 2f;
    private Vector2 movementDirection;
    private Vector2 movementPerSecond;

    private AudioSource audioDeath;
    private Animator animator;
    private Rigidbody2D rBody;

    private Death playerDeath;

    void Start()
    {
        //Script 
        playerDeath = FindObjectOfType<Death>();
        rBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        latestDirectionChangeTime = 0f;
        calcuateNewMovementVector();
    }

    void calcuateNewMovementVector()
    {
        //create a random direction vector with the magnitude of 1, later multiply it with the velocity of the enemy
        movementDirection = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
        movementPerSecond = movementDirection * characterVelocity;
    }

    void Update()
    {
        //if the changeTime was reached, calculate a new movement vector
        if (Time.time - latestDirectionChangeTime > directionChangeTime)
        {
            latestDirectionChangeTime = Time.time;
            calcuateNewMovementVector();
        }

        //move enemy: 
        transform.position = new Vector2(transform.position.x + (movementPerSecond.x * Time.deltaTime),
        transform.position.y + (movementPerSecond.y * Time.deltaTime));
        
        rBody.velocity = movementDirection * characterVelocity;

        ZombieAnimator(movementDirection.x, movementDirection.y);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            audioDeath.Play();

            Destroy(gameObject, 1f);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            playerDeath.KillPlayer("zombie");
            gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }

    private void ZombieAnimator(float dirX, float dirY)
    {
        animator.SetFloat("Horizontal", dirX);
        animator.SetFloat("Vertical", dirY);
    }
}
