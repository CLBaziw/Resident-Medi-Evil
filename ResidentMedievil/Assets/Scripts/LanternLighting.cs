using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LanternLighting : MonoBehaviour
{
    public ChestsPowerUps ChestsPowerUps;

    public Material[] material;

    Renderer rend;



    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (ChestsPowerUps.lantern == true)
        {
            rend.sharedMaterial = material[1];
        }
    }
}
