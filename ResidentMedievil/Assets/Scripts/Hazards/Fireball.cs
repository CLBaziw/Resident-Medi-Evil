using System.Collections;
using System.Windows;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private Vector3 originalPosition;
    private Vector3 newPosition;
    const int max = 3;

    private PlayerDeath death;

    private void Start()
    {
        originalPosition = gameObject.transform.position;
        death = FindObjectOfType<PlayerDeath>();
        newPosition = originalPosition;
    }

    private void FixedUpdate()
    {
        newPosition = gameObject.transform.position;
        Vector3 diffPosition = (newPosition - originalPosition);

        if (Mathf.Abs(diffPosition.x) > max || Mathf.Abs(diffPosition.y) > max)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {      
        if (collision.gameObject.CompareTag("Player"))
        {
            death.Death("fireball");
        }
        
        Destroy(gameObject);
    }
}
