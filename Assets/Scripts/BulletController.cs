using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

	private Transform bullet;
	public AudioClip explosionSound;
	public GameObject explosionEffect;
	public float speed;

	// Use this for initialization
	void Start () {
		bullet = GetComponent<Transform> ();
	}

	void FixedUpdate(){
		bullet.position += Vector3.up * speed;

		if (bullet.position.y >= 6.5)
			Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Alien") {
			Instantiate(explosionEffect, bullet.position, transform.rotation = Quaternion.identity);
			AudioSource.PlayClipAtPoint(explosionSound, transform.position);
			Destroy (other.gameObject);
			Destroy (gameObject);
			PlayerScore.playerScore += 10;
		} 
		else if (other.tag == "Boss") {
			Instantiate(explosionEffect, bullet.position, transform.rotation = Quaternion.identity);
			AudioSource.PlayClipAtPoint(explosionSound, transform.position);
			Destroy(gameObject);
			BossController.bossHealth -= 1;
			PlayerScore.playerScore += 5;
			if (BossController.bossHealth <= 0) {
				Destroy(other.gameObject);
			}
		}
		else if (other.tag == "Base")
		{
			Destroy (gameObject);
		}
		else if (other.tag == "Friendly"){
			Destroy(gameObject);
			GameObject Astro = other.gameObject; // set Astro to be the Astronaut the Radiator ran into
            AstronautControl Astronaut = Astro.GetComponent<AstronautControl>(); // access the script on Astro, which is Astronaut (script)
            Astronaut.health = 0; // set the health of Astro (gameObject) to 0 without affecting other Astronauts
            PlayerScore.playerScore -= 50;
		}		
	}
}