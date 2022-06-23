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

    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Transform> ();
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
            if (RadiatorControl.health >= 5) {
                RadiatorControl.health = 5;
            } else {
                RadiatorControl.health += 1;
            }
        }
    }
}
