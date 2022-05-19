using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    public static float playerScore = 0;
    private TextMeshProUGUI scoreText; 
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI> ();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + playerScore;
    }
}
