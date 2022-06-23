using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RadiatorHealth : MonoBehaviour
{
    private TextMeshProUGUI radiatorHealthText;
    // Start is called before the first frame update
    void Start()
    {
        radiatorHealthText = GetComponent<TextMeshProUGUI> ();
    }

    // Update is called once per frame
    void Update()
    {
        radiatorHealthText.text = "Boss Health: " + RadiatorControl.health;
    }
}
