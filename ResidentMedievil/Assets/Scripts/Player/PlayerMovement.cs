using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 movement;
    public float moveSpeed = 3f;
    //private float moveLimiter = 0.7f;
    public string playerDirection = "down";
    public Animator animator;
    public Rigidbody2D rBody;

    void Update()
    {
        //Grabbing movement
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        //Check for diagonal movement and slow down player speed
        if (movement.x != 0 && movement.y != 0)
        {
            //movement.x *= moveLimiter;
            //movement.y *= moveLimiter;
            movement.y = 0;
        }

        PlayerAnimation();
        PlayerDirection();

        rBody.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);
    }

    void PlayerAnimation()
    {
        if (movement != Vector2.zero)
        {
            //Call animator for movement
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetLayerWeight(1, 1);
        }
        else
        {
            animator.SetLayerWeight(1, 0);
        }
    }

    void PlayerDirection()
    {
        if (movement.x < 0)
        {
            playerDirection = "left";
        }
        else if (movement.x > 0)
        {
            playerDirection = "right";
        }
        else if (movement.y < 0)
        {
            playerDirection = "down";
        }
        else if (movement.y > 0)
        {
            playerDirection = "up";
        }
    }
}
