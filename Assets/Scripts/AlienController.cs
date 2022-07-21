using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class AlienController : MonoBehaviour
{
    public Transform alienHolder;
    public float speed;
    public GameObject shot;
    public float fireRate = 0.99f;
    private GameOver gameOver;

    void Start()
    {
        InvokeRepeating ("MoveAlien", 0.1f, 0.3f);
        alienHolder = GetComponent<Transform> ();
        gameOver = FindObjectOfType<GameOver>();
    }

    void MoveAlien()
    {
        alienHolder.position += Vector3.right * speed;

        foreach (Transform alien in alienHolder)
        {
            if (alien.position.x < -10.5 || alien.position.x > 10.5)
            {
                speed = -speed;
                alienHolder.position += Vector3.down * 0.5f;
                return;
            }

            if (Random.value > fireRate)
            {
                Instantiate(shot, alien.position, alien.rotation);
            }

            if (alien.position.y <= -4)
            {
                gameOver.isPlayerDead = true;
                Time.timeScale = 0;
            }
        }

        if (alienHolder.childCount == 1)
        {
            CancelInvoke();
            InvokeRepeating("MoveAlien", 0.1f, 0.25f);
        }
    
    }
}
