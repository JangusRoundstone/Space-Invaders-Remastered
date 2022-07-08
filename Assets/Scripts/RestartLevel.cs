using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{ 
    private PlayerLives playerLives;
    private GameOver gameOver;

    void Start()
    {
        playerLives =  FindObjectOfType<PlayerLives>();
        gameOver = FindObjectOfType<GameOver>();

    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            PlayerScore.playerScore = 0;
            playerLives.lives = 3;
            gameOver.isPlayerDead = false;
            Time.timeScale = 1;

            SceneManager.LoadScene("Stage 1");
        }
    }
}
