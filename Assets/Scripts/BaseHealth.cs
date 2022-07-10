using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealth : MonoBehaviour
{
    public float health;
    public Sprite[] sprites;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 3)
        {
            spriteRenderer.sprite = sprites[0];
            gameObject.transform.localScale = new Vector3(2, 1.5f, 1);
        }
        else if (health == 2) 
        {
            spriteRenderer.sprite = sprites[1];
            gameObject.transform.localScale = new Vector3(2, 1.5f, 1);
        }
        else if (health == 1)
        {
            spriteRenderer.sprite = sprites[2];
            gameObject.transform.localScale = new Vector3(2, 1.5f, 1);
        }
        else if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
