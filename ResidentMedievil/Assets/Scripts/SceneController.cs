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

            if (teleporterName == "Teleporter_Tutorial") //Teleporter from Scene1 to Tutorial
            {
                SceneManager.LoadScene(9);
            }
            else if (teleporterName == "Teleporter_Scene1") //Teleporter from Tutorial to Scene1
            {
                SceneManager.LoadScene(0);
            }
            else if (teleporterName == "Teleporter_Final") //Teleporter from Scene1 alternate route to Final scene.
            {
                SceneManager.LoadScene(8);
            }
            else if (teleporterName == "Teleporter_S1TP2") //Teleporter back to first scene to take alternate route.
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
                SceneManager.LoadScene(nextSceneIndex);
            }
        }
    }
}
