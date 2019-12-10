using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{

    //public DashState dashState;
    public int dashState = 0;
    public float dashTimer;
    public float maxDash = 20f;

    public Vector2 savedVelocity;
    public Rigidbody2D rBody;

    private void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        switch (dashState)
        {
            case 0: //Ready to dash
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    savedVelocity = rBody.velocity; //savedVelocity = original velocity
                    savedVelocity = new Vector2(rBody.velocity.x * 3f, GetComponent<Rigidbody2D>().velocity.y); //Increase velocity
                    dashState = 1; //Change state to dashing
                }
                break;
            case 1:
                //dashTimer += Time.deltaTime * 3;
                //if (dashTimer >= maxDash) //
                //{
                //    dashTimer = maxDash;
                //    GetComponent<Rigidbody2D>().velocity = savedVelocity;
                //    dashState = 2;
                //}

                while (dashTimer < maxDash)
                {
                    rBody.velocity = savedVelocity;
                    dashTimer += Time.deltaTime * 3;
                }

                dashState = 2;
                break;
            case 2:
                dashTimer -= Time.deltaTime;
                if (dashTimer <= 0)
                {
                    dashTimer = 0;
                    dashState = 0;
                }
                break;
        }
    }
}

//public enum DashState
//{
//    Ready,
//    Dashing,
//    Cooldown
//}