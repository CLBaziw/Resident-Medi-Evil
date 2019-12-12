using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 newPosition;
    const int max = 3;

    //public GameObject hitEffect;
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (!collision.gameObject.CompareTag("Player") && !collision.gameObject.CompareTag("Bullet") && !collision.gameObject.CompareTag("Holes"))
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        newPosition = gameObject.transform.position;
        Vector3 diffPosition = (newPosition - player.position);

        if (Mathf.Abs(diffPosition.x) > max || Mathf.Abs(diffPosition.y) > max)
        {
            Destroy(gameObject);
        }
    }
}
