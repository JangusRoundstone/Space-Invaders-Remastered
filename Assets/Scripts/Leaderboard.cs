using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Leaderboard : MonoBehaviour
{
    public int highScore;
    public int previousScore;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI previousScoreText;

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        previousScore = PlayerPrefs.GetInt("PreviousScore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        highScoreText.text = highScore.ToString();
        previousScoreText.text = previousScore.ToString();
    }

    public void Reset()
    {
        PlayerPrefs.DeleteKey("HighScore");
        PlayerPrefs.DeleteKey("PreviousScore");
        highScoreText.text = "0";
        previousScoreText.text = "0";
    }
}
