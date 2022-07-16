using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartController : MonoBehaviour
{
    private PlayerLives playerLives;
    public Healthbar playerHealthBar;

    void Start() {
        playerLives = FindObjectOfType<PlayerLives>();
    }

    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Bullet") {
            playerHealthBar.SetHealth(playerLives.lives);
        }
    }
}
