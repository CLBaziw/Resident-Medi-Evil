using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rBody;
    private Endgame endgame;

    private PlayerAttack playerAttack;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody2D>();
        endgame = FindObjectOfType<Endgame>();

        playerAttack = FindObjectOfType<PlayerAttack>();
        playerAttack.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void KillPlayer(string killer)
    {
        animator.SetBool("Death", true);
        rBody.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;
        playerAttack.enabled = false;

        //Display endgame screen
        endgame.GameOver("lose");
    }
}
