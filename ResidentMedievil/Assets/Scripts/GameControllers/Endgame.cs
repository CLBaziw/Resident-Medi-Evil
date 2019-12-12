using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Endgame : MonoBehaviour
{
    public float score = 0;

    private GameController tracker;

    public GameObject gameOverScreen;
    public GameObject winScreen;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        tracker = FindObjectOfType<GameController>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //When endgame collider is trigger, trigger endgame.
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            GameOver("win");
        }
    }

    public void GameOver(string winLose)
    {
        GameObject endScreen;
        
        if (!tracker.lantern) 
        {
            GameObject fogWar = GameObject.Find("FogOfWar");
            fogWar.SetActive(false);
        }
        
        Debug.Log(winLose);

        Text scoreDisplay = GameObject.Find("Score").GetComponent<Text>(); ;

        if (winLose == "win")
        {
            endScreen = winScreen;
        }
        else
        {
            endScreen = gameOverScreen;
        }

        Instantiate(endScreen, player.transform);
        scoreDisplay.text = "Score: " + score;

        IEnumerator restart = WaitRestart();

        StartCoroutine(restart);
    }

    IEnumerator WaitRestart()
    {
        yield return new WaitForSeconds(6f);

        SceneManager.LoadScene(0);
    }
}

