using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerLives : MonoBehaviour
{
    public float lives = 3;
    private TextMeshProUGUI livesText;
    public bool isTakingDamage = false;
    private PlayerController playerRender;
    private PlayerController playerColour;

    // Start is called before the first frame update
    void Start()
    {
        livesText = GetComponent<TextMeshProUGUI>();
        playerRender = FindObjectOfType<PlayerController>();
        playerColour = FindObjectOfType<PlayerController>();
        //render = GetComponent<Renderer>();
		//colour = render.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        livesText.text = "Lives: " + lives;
    }

    public void TakeDamage() {
        if (!isTakingDamage) { //prevent player losing 2 or more lives in a row after getting hit once
            lives -= 1;
            isTakingDamage = true;
            StartCoroutine(Immunity());
        }
		
	}

    IEnumerator Immunity() {
        playerColour.colour.a = 0.5f; //change alpha to make it translucent
		playerRender.render.material.color = playerColour.colour;
        yield return new WaitForSeconds(1.5f);
        isTakingDamage = false;
        playerColour.colour.a = 1f;
		playerRender.render.material.color = playerColour.colour;
    }
}
