using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class RadiatorControl : MonoBehaviour
{
    private Transform Radiator;

    private Transform RadiatorSpawn;

    public Transform Player;

    new private Transform transform;

    public float speed; 

    private SpriteRenderer spriteRenderer_Peace;

    public Sprite[] sprites;

    private Rigidbody2D rigidBody; 

    private bool ToCharge = false;

    private Vector2 startPos;

    public static float health = 5;

    private bool Alive = true;

    private float NextCharge = 0;

    public float ChargeRate = 9;

    Collider2D m_Collider;

    Vector3 respawn = new Vector3(0, -5, 0);

    public AudioClip chargingUpSound;

    public AudioClip explosionSound;

    public GameObject explosionEffect;

    void Start()
    {
        Radiator = GetComponent<Transform>();
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer_Peace = gameObject.GetComponent<SpriteRenderer>();
        transform = Player.GetComponent<Transform>();
        startPos = Radiator.position;
        m_Collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Math.Abs(Radiator.position.x - transform.position.x) <= 0.5f && Alive == true && Time.time > NextCharge){
            AudioSource.PlayClipAtPoint(chargingUpSound, transform.position);
            NextCharge += ChargeRate;
            ToCharge = true;
            StartCoroutine(ChangeSprite());
        }
        else if(Radiator.position.x < transform.position.x && ToCharge == false){
            Radiator.position += Vector3.right * speed;
        }
        else if(Radiator.position.x > transform.position.x && ToCharge == false){
            Radiator.position += Vector3.left * speed;
        }       
    }
    
    IEnumerator ChangeSprite()
    {
        for(int i = 0; i < 3; i++)
        {
            double wait = 0.5-i*0.2;

            spriteRenderer_Peace.sprite = sprites[1];
            yield return new WaitForSeconds((float)wait);

            spriteRenderer_Peace.sprite = sprites[0];
            yield return new WaitForSeconds((float)wait);
        }

        rigidBody.velocity = new Vector3(0, 5, 0);

        while(Radiator.position.y < 10)
        {
            spriteRenderer_Peace.sprite = sprites[1];
            yield return new WaitForSeconds(0.3f);

            spriteRenderer_Peace.sprite = sprites[0];
            yield return new WaitForSeconds(0.3f);
        }
        Radiator.position = startPos;
        rigidBody.velocity = new Vector3(0, 0, 0);
        ToCharge = false;        
    }

    IEnumerator DeathThroes()
    {
        m_Collider.enabled = false;
        for(int i = 0; i < 5; i++)
        { 
            spriteRenderer_Peace.sprite = sprites[1];
            yield return new WaitForSeconds(0.25f);

            spriteRenderer_Peace.sprite = sprites[2];
            yield return new WaitForSeconds(0.25f);
        }
        Destroy(gameObject);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(explosionEffect, Radiator.position, transform.rotation = Quaternion.identity);
        AudioSource.PlayClipAtPoint(explosionSound, transform.position);
        if (other.tag == "Player")
        {
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
            GameObject playerBase = other.gameObject;
            BaseHealth baseHealth = playerBase.GetComponent<BaseHealth>();
            baseHealth.health = 0;
        }
        else if (other.tag == "Bullet"){
            health -= 1;
            Destroy(other.gameObject);
            if(health <= 0){
                Alive = false;
                StopAllCoroutines();
                rigidBody.velocity = new Vector3(0, 0, 0);
                StartCoroutine(DeathThroes());
            }
        }
        else if(other.tag == "Friendly"){
            GameObject Astro = other.gameObject; // set Astro to be the Astronaut the Radiator ran into
            AstronautControl Astronaut = Astro.GetComponent<AstronautControl>(); // access the script on Astro, which is Astronaut (script)
            Astronaut.health = 0; // set the health of Astro (gameObject) to 0 without affecting other Astronauts
        }
        else{
            Destroy(other.gameObject);
        }
    }
}
