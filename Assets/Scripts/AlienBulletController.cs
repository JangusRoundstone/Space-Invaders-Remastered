using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBulletController : MonoBehaviour
{
    private AudioSource explosion;
    private Transform bullet;
    public float speed;
    Vector3 respawn = new Vector3(0, -5, 0);

    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Transform> ();
        explosion = GetComponent<AudioSource> ();
    }

    void FixedUpdate()
    {
        bullet.position += Vector3.up * -speed;

        if (bullet.position.y <= -10)
        {
            Destroy(bullet.gameObject);
        }
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            explosion.Play();
            if (PlayerLives.playerLives == 1) 
            {
                PlayerLives.playerLives = 0;
                Destroy(other.gameObject);
                Destroy(gameObject);
                GameOver.isPlayerDead = true;
            } else 
            {
                PlayerLives.playerLives -= 1;
                other.gameObject.transform.position = respawn;
                GameManager.playGame = false;
            }
         
        } else if (other.tag == "Base")
        {
            GameObject playerBase = other.gameObject;
            BaseHealth baseHealth = playerBase.GetComponent<BaseHealth> ();
            baseHealth.health -= 1;
            Destroy(gameObject);
        }
    }
}
