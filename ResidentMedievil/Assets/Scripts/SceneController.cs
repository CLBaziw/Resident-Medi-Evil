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

    void OnTriggerStay(Collider other)
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        Debug.Log("Trigger");

        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
