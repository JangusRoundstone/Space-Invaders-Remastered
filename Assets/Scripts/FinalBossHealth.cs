using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalBossHealth : MonoBehaviour
{
    private TextMeshProUGUI finalBossHealthText;
    private BossController health;
    // Start is called before the first frame update
    void Start()
    {
        finalBossHealthText = GetComponent<TextMeshProUGUI>();
        health = FindObjectOfType<BossController>();
    }

    // Update is called once per frame
    void Update()
    {
        finalBossHealthText.text = "Boss Health: " + health.bossHealth;
    }
}
