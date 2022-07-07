using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerLives : MonoBehaviour
{
    public float lives = 3;
    private TextMeshProUGUI livesText;
    public bool isTakingDamage = false;
    // Start is called before the first frame update
    void Start()
    {
        livesText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        livesText.text = "Lives: " + lives;
    }

    public void TakeDamage() {
        if (!isTakingDamage) {
            lives -= 1;
            isTakingDamage = true;
            StartCoroutine(RemoveImmunity());
        }
		
	}

    IEnumerator RemoveImmunity() {
        yield return new WaitForSeconds(1);
        isTakingDamage = false;
    }
}
