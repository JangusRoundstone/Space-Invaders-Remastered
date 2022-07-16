using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RadiatorHealth : MonoBehaviour
{
    private TextMeshProUGUI radiatorHealthText;
    private RadiatorControl radiatorHealth;
    public Healthbar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        radiatorHealthText = GetComponent<TextMeshProUGUI> ();
        radiatorHealth = FindObjectOfType<RadiatorControl>();
        healthBar.SetMaxHealth(radiatorHealth.health);
    }

    // Update is called once per frame
    void Update()
    {
        //radiatorHealthText.text = "Boss Health: " + radiatorHealth.health;
    }
}
