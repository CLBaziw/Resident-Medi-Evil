using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamethrower : MonoBehaviour
{
    List<Transform> firepoints = new List<Transform>();

    //Bullet prefabs
    public GameObject fbPrefabRight;
    public GameObject fbPrefabLeft;
    public GameObject fbPrefabUp;
    public GameObject fbPrefabDown;

    private GameObject activeFireball;

    private float fireballForce = 5f;
    private Vector2 fireballV = new Vector2(0, 0); 

    void Start()
    {
        firepoints.Clear();

        foreach (Transform child in transform)
        {
            firepoints.Add(child);
        }

        StartCoroutine("Fireball");
    }
    //Every 3 seconds fire a fireball
    IEnumerator Fireball()
    {
        for (; ; )
        {
            for (int i = 0; i < firepoints.Count; i++)
            {
                Vector3 positionFP = (firepoints[i].localPosition);

                if (positionFP.x > 0) //Right
                {
                    activeFireball = fbPrefabRight;
                    fireballV = new Vector2(1, 0);
                }
                else if (positionFP.x < 0) //Left
                {
                    activeFireball = fbPrefabLeft;
                    fireballV = new Vector2(-1, 0);
                }
                else if (positionFP.y > 0) //Up
                {
                    activeFireball = fbPrefabUp;
                    fireballV = new Vector2(0, 1);
                }
                else if (positionFP.y < 0) //Down
                {
                    activeFireball = fbPrefabDown;
                    fireballV = new Vector2(0, -1);
                }

                GameObject fireball = Instantiate(activeFireball, firepoints[i].position, activeFireball.transform.rotation);

                Rigidbody2D rbFireball = fireball.GetComponent<Rigidbody2D>();

                rbFireball.AddForce(fireballV * fireballForce, ForceMode2D.Impulse);
            }

            yield return new WaitForSeconds(0.8f); //Shoot again in __ second
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Kill player
            Debug.Log("Player ran into flamethrower");
        }
    }
}
