using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScenesLoader : MonoBehaviour
{
    public TextMeshProUGUI getReadyStage2;
    public TextMeshProUGUI getReadyStage3;

    IEnumerator WaitBeforeStage2()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("Stage 2");
    }

    IEnumerator WaitBeforeStage3()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("Stage 3");
    }

    void Start()
    {
        if (getReadyStage2 != null)
        {
            getReadyStage2.enabled = false;
        }

        if (getReadyStage3 != null)
        {
            getReadyStage3.enabled = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (PlayerScore.playerScore == 240 && SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (getReadyStage2 != null)
            {
                getReadyStage2.enabled = true;
            }
            StartCoroutine(WaitBeforeStage2());
        }
       
        else if (SceneManager.GetActiveScene().buildIndex == 2 && AlienController.alienHolder.childCount == 0 && RadiatorControl.health == 0)
        {
            if (getReadyStage3 != null)
            {
                getReadyStage3.enabled = true;
            }
            StartCoroutine(WaitBeforeStage3());
        }
    }
}
