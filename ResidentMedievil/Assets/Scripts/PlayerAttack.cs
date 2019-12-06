using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //Bullet prefabs
    public GameObject bulletPrefabRight;
    public GameObject bulletPrefabLeft;
    public GameObject bulletPrefabUp;
    public GameObject bulletPrefabDown;

    private PlayerMovement scriptMove; //PlayerMovement.cs script
    private Transform activeFP; //Holds FirePoint in the direction the player is facing
    private GameObject activeBullet; //Holds Prefab for the direction the player is facing

    //Delay attack
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    private float bulletForce = 5f;
    private Vector2 playV;
    

    private void Start()
    {
        scriptMove = GameObject.FindObjectOfType<PlayerMovement>();
        activeFP = GameObject.Find("FirePoint_Down").GetComponent<Transform>();
        activeBullet = bulletPrefabDown;
    }
    void FixedUpdate()
    {
        if(timeBtwAttack <= 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                getFirePoint();
                Debug.Log("Player direction: " + scriptMove.playerDirection + "FP: " + activeFP + "Sprite: " + activeBullet);
                //Fire bullet at position of activeFP
                GameObject bullet = Instantiate(activeBullet, activeFP.position, activeBullet.transform.rotation);

                Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();

                rbBullet.AddForce(playV * bulletForce, ForceMode2D.Impulse);
            }
            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    void getFirePoint()
    {
        switch (scriptMove.playerDirection)
        {
            case "left":
                activeFP = GameObject.Find("FirePoint_Left").GetComponent<Transform>();
                activeBullet = bulletPrefabLeft;
                playV = new Vector2(-1, 0);
                break;
            case "right":
                activeFP = GameObject.Find("FirePoint_Right").GetComponent<Transform>();
                activeBullet = bulletPrefabRight;
                playV = new Vector2(1, 0);
                break;
            case "up":
                activeFP = GameObject.Find("FirePoint_Up").GetComponent<Transform>();
                activeBullet = bulletPrefabUp;
                playV = new Vector2(0, 1);
                break;
            case "down":
                activeFP = GameObject.Find("FirePoint_Down").GetComponent<Transform>();
                activeBullet = bulletPrefabDown;
                playV = new Vector2(0, -1);
                break;
        }
    }
}
