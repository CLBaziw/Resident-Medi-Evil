using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            string teleporterName = gameObject.name;

            //If the teleporter will be used for the tutorial, do not advance to next scene
            //Skip to scene 8
            if (teleporterName == "Teleporter_Tutorial")
            {
                SceneManager.LoadScene(8);
            }
            else if (teleporterName == "Teleporter_Scene1")
            {
                SceneManager.LoadScene(0);
            }
            //Teleporter takes you to next scene
            //Provided the teleporter is not used for the tutorial level
            else{
                int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
                SceneManager.LoadScene(nextSceneIndex);
            }
        }
    }
}
