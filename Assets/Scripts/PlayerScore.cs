using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    public static int playerScore = 0;
    private TextMeshProUGUI scoreText;
    public int highScore;
    public int previousScore;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI> ();
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        previousScore = PlayerPrefs.GetInt("PreviousScore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScore <= 0) {
            playerScore = 0;
        }

        if (playerScore > highScore) {
            PlayerPrefs.SetInt("HighScore", playerScore);
            PlayerPrefs.Save();
        }
        scoreText.text = "Score: " + playerScore;
        PlayerPrefs.SetInt("PreviousScore", playerScore);
    }
}
