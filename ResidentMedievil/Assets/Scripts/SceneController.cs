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
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        Debug.Log("trigger");

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("If statement triggered");

            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
