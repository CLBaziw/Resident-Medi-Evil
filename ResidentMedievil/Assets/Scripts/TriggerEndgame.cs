﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEndgame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //When endgame collider is trigger, trigger endgame.
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger Endgame");
    }
}
