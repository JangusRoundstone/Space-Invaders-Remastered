using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalBossHealth : MonoBehaviour
{
    private TextMeshProUGUI finalBossHealthText;
    // Start is called before the first frame update
    void Start()
    {
        finalBossHealthText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        finalBossHealthText.text = "Boss Health: " + BossController.bossHealth;
    }
}
