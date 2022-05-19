using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameOver : MonoBehaviour
{
    public static bool isPlayerDead =  false;
    private TextMeshProUGUI gameOver;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = GetComponent<TextMeshProUGUI> ();
        if (gameOver != null) 
        {
            gameOver.enabled = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerDead) 
        {
            Time.timeScale = 0;
            gameOver.enabled = true;
        }
    }
}
