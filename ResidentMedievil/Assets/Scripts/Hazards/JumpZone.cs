using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpZone : MonoBehaviour
{
    private GameController checkPowerups;

    private void Start()
    {
        checkPowerups = GameObject.FindObjectOfType<GameController>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.Space))
            {
                //Jump
                //Holes don't kill character
            }
        }
    }
}
