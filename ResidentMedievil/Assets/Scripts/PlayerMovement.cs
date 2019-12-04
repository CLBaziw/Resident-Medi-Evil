using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Public variables
    public float moveSpeed = 3f;
    public Vector2 movement;
    public Animator animator;

    //public GameObject laser;
    //public Transform laserSpawn;
    //public float fireRate = 0.5f;

    //Private variables
    private Rigidbody2D rBody;

    public Transform firePointRight;
    public Transform firePointUp;
    public Transform firePointLeft;
    public Transform firePointDown;
    public GameObject bulletPrefabRight;
    public GameObject bulletPrefabLeft;
    public GameObject bulletPrefabUp;
    public GameObject bulletPrefabDown;
    public float bulletForce = 0.9f;
    public float bulletForceLeft = -0.9f;
    public int keepdown = 0;
    public int keepup = 0;
    public int keepleft = 0;
    public int keepright = 0;


    private float counter = 0.0f;
    public float fireRate = 0.5f;

    private float horizontal;
    private float vertical;

    //private float counter = 0.0f;

    private void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Grabbing movement
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        Debug.Log($"Movement in X: {movement.x}");
        Debug.Log($"Movement in Y: {movement.y}");

        ///////////////   LASER     ////////////////////////////
        counter += Time.deltaTime;

        if (movement.x == 1)
        {
            keepright = 1;
            keepdown = 0;
            keepleft = 0;
            keepup = 0;
            if (Input.GetButton("Fire1") && counter > fireRate)
            {

                // Instantiate the laser
                GameObject bullet = Instantiate(bulletPrefabRight, firePointRight.position, bulletPrefabRight.transform.rotation);
                counter = 0.0f;
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

                //rb.AddForce(firePoint.position * bulletForce, ForceMode2D.Impulse);
                rb.AddForce(firePointRight.position * bulletForce, ForceMode2D.Impulse );

            }
        }
        else if (movement.x == -1)
        {
            keepright = 0;
            keepdown = 0;
            keepleft = 1;
            keepup = 0;
            if (Input.GetButton("Fire1") && counter > fireRate)
            {

                // Instantiate the laser
                GameObject bullet = Instantiate(bulletPrefabLeft, firePointLeft.position, bulletPrefabLeft.transform.rotation);
                counter = 0.0f;
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

                rb.AddForce(firePointLeft.position * bulletForceLeft, ForceMode2D.Force);

            }
        }
        else if (movement.y == 1)
        {
            keepright = 0;
            keepdown = 0;
            keepleft = 0;
            keepup = 1;
            if (Input.GetButton("Fire1") && counter > fireRate)
            {

                // Instantiate the laser
                GameObject bullet = Instantiate(bulletPrefabUp, firePointUp.position, bulletPrefabUp.transform.rotation);
                counter = 0.0f;
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

                rb.AddForce(firePointUp.position * bulletForce, ForceMode2D.Impulse);

            }
        }
        else if (movement.y == -1)
        {
            keepright = 0;
            keepdown = 1;
            keepleft = 0;
            keepup = 0;
            if (Input.GetButton("Fire1") && counter > fireRate)
            {
                // Instantiate the laser
                GameObject bullet = Instantiate(bulletPrefabDown, firePointDown.position, bulletPrefabDown.transform.rotation);
                counter = 0.0f;
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

                rb.AddForce(firePointDown.position * bulletForce, ForceMode2D.Impulse);

            }
        }
        else
        {
            Debug.Log("NOTHINGGGGGGGGGGGGGGGGGG"); 
        }
        if (keepright == 1)
            {
                if (Input.GetButton("Fire1") && counter > fireRate)
                {
                    // Instantiate the laser
                    GameObject bullet = Instantiate(bulletPrefabRight, firePointRight.position, bulletPrefabRight.transform.rotation);
                    counter = 0.0f;
                    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

                    rb.AddForce(firePointRight.position * bulletForce, ForceMode2D.Impulse);

                }
            }
            else if (keepleft == -1)
            {
                if (Input.GetButton("Fire1") && counter > fireRate)
                {
                    // Instantiate the laser
                    GameObject bullet = Instantiate(bulletPrefabLeft, firePointLeft.position, bulletPrefabLeft.transform.rotation);
                    counter = 0.0f;
                    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

                    rb.AddForce(firePointLeft.position * bulletForce, ForceMode2D.Impulse);

                }
            }
            else if (keepup == 1)
            {
                if (Input.GetButton("Fire1") && counter > fireRate)
                {
                    // Instantiate the laser
                    GameObject bullet = Instantiate(bulletPrefabUp, firePointUp.position, bulletPrefabUp.transform.rotation);
                    counter = 0.0f;
                    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

                    rb.AddForce(firePointUp.position * bulletForce, ForceMode2D.Impulse);

                }
            }
            else if (keepdown == -1)
            {
                if (Input.GetButton("Fire1") && counter > fireRate)
                {
                    // Instantiate the laser
                    GameObject bullet = Instantiate(bulletPrefabDown, firePointDown.position, bulletPrefabDown.transform.rotation);
                    counter = 0.0f;
                    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

                    rb.AddForce(firePointDown.position * bulletForce, ForceMode2D.Impulse);

                }
            }
            else
            {
                //Debug.Log("NOTHINGGGGGGGGGGGGGGGGGG");
            }
        




    }
    //void DestroyObjectDelayed()
    //{
    //    // Kills the game object in 5 seconds after loading the object
    //    Destroy(laserSpawn, 5);
    //}
    void FixedUpdate()
    {
        //horizontal = Input.GetAxisRaw("Horizontal");
        //vertical = Input.GetAxisRaw("Vertical");
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
