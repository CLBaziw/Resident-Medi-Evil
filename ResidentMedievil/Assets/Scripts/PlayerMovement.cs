using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Public variables
    public float moveSpeed = 3f;
    public Vector2 movement;
    public Animator animator;
    
    //Private variables
    private Rigidbody2D rBody;

    private void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Grabbing movement
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
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

        rBody.MovePosition(rBody.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
