using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBulletController : MonoBehaviour
{
    public AudioClip explosionSound;
    public AudioClip healingSound;
    private Transform bullet;
    public GameObject explosionEffect;
    public GameObject healingEffect;
    public float speed;
    Vector3 respawn = new Vector3(0, -5, 0);
    private PlayerLives playerLives;
    private GameOver gameOver;
    private RadiatorControl radiatorHealth;
    //private PlayerController playerPosition;

    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Transform> ();
        playerLives =  FindObjectOfType<PlayerLives>();
        gameOver = FindObjectOfType<GameOver>();
        radiatorHealth = FindObjectOfType<RadiatorControl>();
        //playerPosition = FindObjectOfType<PlayerController>();
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
            Instantiate(explosionEffect, bullet.position, transform.rotation = Quaternion.identity);
			AudioSource.PlayClipAtPoint(explosionSound, transform.position);
            if (playerLives.lives <= 1) 
            {
                playerLives.lives = 0;
                Destroy(other.gameObject);
                Destroy(gameObject);
                gameOver.isPlayerDead = true;
            } else 
            {
                playerLives.TakeDamage();
                Destroy(gameObject);
            }
         
        } 
        else if (other.tag == "Base")
        {
            Instantiate(explosionEffect, bullet.position, transform.rotation = Quaternion.identity);
			AudioSource.PlayClipAtPoint(explosionSound, transform.position);
            GameObject playerBase = other.gameObject;
            BaseHealth baseHealth = playerBase.GetComponent<BaseHealth> ();
            baseHealth.health -= 1;
            Destroy(gameObject);
        } 
        else if (other.tag == "Radiator")
        {
            Instantiate(healingEffect, bullet.position, transform.rotation = Quaternion.identity);
			AudioSource.PlayClipAtPoint(healingSound, transform.position);
            Destroy(gameObject);
            if (radiatorHealth.health >= 5) {
                radiatorHealth.health = 5;
            } else {
                radiatorHealth.health += 1;
            }
        }
    }
}
