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

    public void BackButton()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
