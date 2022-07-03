using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class AlienController : MonoBehaviour
{
    public static Transform alienHolder;
    public float speed;
    public GameObject shot;
    public float fireRate = 0.99f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating ("MoveAlien", 0.1f, 0.3f);
        alienHolder = GetComponent<Transform> ();
    }

    // Update is called once per frame
    void MoveAlien()
    {
        if (GameManager.playGame)
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
                    GameOver.isPlayerDead = true;
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
}
