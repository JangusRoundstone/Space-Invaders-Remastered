using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject pauseButton;
    

    public void PlayButton()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Stage 1");
    }

    public void HowToPlayButton()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("How To Play");
    }

    public void BackButton_HowToPlay()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Main Menu");
    }

    public void NextButton_HowToPlay()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Walkthrough");
    }

    public void BackButton_Walkthrough()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("How To Play");
    }

    public void ReturnButton_Walkthrough()
    {
        Time.timeScale = 1.0f;
        PlayerScore.playerScore = 0;
        SceneManager.LoadScene("Main Menu");
    }

    public void PauseButton()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void ResumeButton()
    {
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void QuitButton() 
    {
        Application.Quit();
    }
}
