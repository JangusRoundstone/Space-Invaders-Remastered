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
    private PlayerController damageStatus;
    public Healthbar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        livesText = GetComponent<TextMeshProUGUI>();
        playerRender = FindObjectOfType<PlayerController>();
        playerColour = FindObjectOfType<PlayerController>();
        damageStatus = FindObjectOfType<PlayerController>();
        healthBar.SetMaxHealth(lives);
    }

    // Update is called once per frame
    void Update()
    {
        //livesText.text = "Lives: " + lives;
    }

    public void TakeDamage() {
        if (!isTakingDamage) { //prevent player losing 2 or more lives in a row after getting hit once
            lives -= 1;
            healthBar.SetHealth(lives);
            isTakingDamage = true;
            damageStatus.animator.SetBool("IsTakingDamage", true);
            StartCoroutine(Immunity());
        }
		
	}

    IEnumerator Immunity() {
        playerColour.colour.a = 0.5f; //change alpha to make it translucent
		playerRender.render.material.color = playerColour.colour;
        yield return new WaitForSeconds(1.5f);
        isTakingDamage = false;
        damageStatus.animator.SetBool("IsTakingDamage", false);
        playerColour.colour.a = 1f;
		playerRender.render.material.color = playerColour.colour;
    }
}
