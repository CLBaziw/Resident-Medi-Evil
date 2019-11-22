using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public int nextScene = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D player)
    {
        const int FIRST = 0;
        const int FINAL = 8;
        const int TUTORIAL = 9;

        if (player.gameObject.tag == "Player")
        {
            string teleporterName = gameObject.name;

            if (teleporterName == "Teleporter_Tutorial") //Teleporter from Scene1 to Tutorial
            {
                nextScene = TUTORIAL;
            }
            else if (teleporterName == "Teleporter_Scene1") //Teleporter from Tutorial to Scene1
            {
                nextScene = FIRST;
            }
            else if (teleporterName == "Teleporter_Final") //Teleporter from Scene1 alternate route to Final scene.
            {
                nextScene = FINAL;
            }
            else if (teleporterName == "Teleporter_S1TP2") //Teleporter back to first scene to take alternate route.
            {
                nextScene = FIRST;
            }
            else
            {
                nextScene = SceneManager.GetActiveScene().buildIndex + 1;
                
            }

            changeScene(nextScene, player);
        }
    }

    void changeScene (int nextScene, Collider2D player)
    {
        SceneManager.LoadScene(nextScene);
        SceneManager.MoveGameObjectToScene(player.gameObject, SceneManager.GetSceneByBuildIndex(nextScene));
    }
}
