using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AstronautControl : MonoBehaviour
{
    public float health = 100;
    private bool NoCoroutine = true;
    private float PoisonRate = 1;
    private float Poison;
    public Sprite[] sprites;
    private SpriteRenderer LocalSprite;
    public GameObject enemy;
    new private Transform transform;
    public float speed;
    Collider2D m_Collider;

    // Start is called before the first frame update
    void Start()
    {
        LocalSprite = GetComponent<SpriteRenderer>();
        m_Collider = GetComponent<Collider2D>();
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > Poison){
            health -= 1;
            Poison += PoisonRate;
        }

        if (health <= 0 && NoCoroutine){
            NoCoroutine = false;
            transform.SetParent(null);
            StartCoroutine(ChangeSprite());
        }

        if (enemy == null && NoCoroutine){
            m_Collider.enabled = false;
            transform.SetParent(null);
            LocalSprite.sprite = sprites[1];
            transform.position += Vector3.up * speed; 
            if (transform.position.y > 10){
                Destroy(gameObject);
                PlayerScore.playerScore += 100;
            }
        }
    }

    IEnumerator ChangeSprite()
    {
        for(int i = 0; i < 2; i++)
        {
            LocalSprite.sprite = sprites[2];
            yield return new WaitForSeconds(0.5f);

            LocalSprite.sprite = sprites[0];
            yield return new WaitForSeconds(0.5f);
        }
        Destroy(gameObject);
        PlayerScore.playerScore -= 50;
    }
}
