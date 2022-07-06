using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class BossController : MonoBehaviour
{

    private Transform bossHolder;
    public Transform boss;
    public Transform player;
    public Transform alienHolder;
    public Transform rightGun;
    public Transform leftGun;
    public Transform bossEye;
    public float speed;
    public GameObject bossShot;
    public GameObject alienShot;
    public GameObject bossLaser;
    public TextMeshProUGUI winText;
    public float fireRate;
    public static float bossHealth = 50;
    public AudioClip victoryNote;
    private bool hasVictoryNotePlayed = false;
    // Start is called before the first frame update
    void Start()
    {
        if (winText != null)
        {
            winText.enabled = false;
        }
        InvokeRepeating ("MoveBoss", 0.1f, 0.3f);
        bossHolder = GetComponent<Transform> ();
    }

    // Update is called once per frame
    void MoveBoss()
    {
        if (GameManager.playGame)
        {
            bossHolder.position += Vector3.right * speed;
            if (alienHolder.childCount == 0)    {
                bossHolder.position += Vector3.right * (speed * 2);
                fireRate = 0.8f;
            }

            foreach (Transform enemy in bossHolder)
            {
                if (enemy.position.x < -7.5 || enemy.position.x > 8)
                {
                    speed = -speed;
                    return;
                }

                if (UnityEngine.Random.value > fireRate && rightGun != null && leftGun != null)
                {
                    Instantiate(bossShot, rightGun.position, rightGun.rotation);
                    Instantiate(bossShot, leftGun.position, leftGun.rotation);
                }

            }

            foreach (Transform alien in alienHolder)
            {
                if (UnityEngine.Random.value > fireRate)
                {
                    Instantiate(alienShot, alien.position, alien.rotation);
                }
            }
            
            if (bossEye != null && player != null && alienHolder != null && Math.Abs(boss.position.x - player.position.x) <= 0.5f)
            {
                Instantiate(bossLaser, bossEye.position, bossEye.rotation);
            }

            if (SceneManager.GetActiveScene().buildIndex == 3 && alienHolder.childCount == 0 && bossHealth == 0)
            {
                
                if (winText != null)
                {
                     winText.enabled = true;
                }
                   
                if (!hasVictoryNotePlayed) {
                    AudioSource.PlayClipAtPoint(victoryNote, new Vector3(0, 0, -20));
                    hasVictoryNotePlayed = true;
                }
                 
            }

        }
        
    }
}
