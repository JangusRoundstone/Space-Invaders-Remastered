using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameOver : MonoBehaviour
{
    public bool isPlayerDead =  false;
    public TextMeshProUGUI gameOver;
    public TextMeshProUGUI restart;
    // Start is called before the first frame update
    void Start()
    {
        if (gameOver != null) 
        {
            gameOver.enabled = false;
        }
        if (restart != null) 
        {
            restart.enabled = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerDead) 
        {
            Time.timeScale = 0;
            gameOver.enabled = true;
            restart.enabled = true;
        }
    }
}
