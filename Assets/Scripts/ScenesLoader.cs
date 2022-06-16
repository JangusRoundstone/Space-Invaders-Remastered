using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesLoader : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (PlayerScore.playerScore == 240 && SceneManager.GetActiveScene().buildIndex == 1)
        {
            SceneManager.LoadScene("Stage 2");
        }
        
    }
}
