using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossHealth : MonoBehaviour
{
    private BossController health;
    public Healthbar bossHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        health = FindObjectOfType<BossController>();
        bossHealthBar.SetMaxHealth(health.bossHealth);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Bullet") {
            bossHealthBar.SetHealth(health.bossHealth);
        }
    }
}
