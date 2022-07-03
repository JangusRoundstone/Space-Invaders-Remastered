using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMain : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3 && Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene("Main Menu");
        }
    
    }
}
