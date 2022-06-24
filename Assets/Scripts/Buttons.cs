using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("Stage 1");
    }

    public void HowToPlayButton()
    {
        SceneManager.LoadScene("How To Play");
    }

    public void BackButton_HowToPlay()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void NextButton_HowToPlay()
    {
        SceneManager.LoadScene("Walkthrough");
    }

    public void BackButton_Walkthrough()
    {
        SceneManager.LoadScene("How To Play");
    }

    public void ReturnButton_Walkthrough()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
