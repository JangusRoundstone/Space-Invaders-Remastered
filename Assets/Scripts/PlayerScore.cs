using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public static float playerScore = 0;
    private Text scoreText; 
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text> ();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + playerScore;
    }
}
