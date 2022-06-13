using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

	private Transform bullet;
	public AudioClip explosion;
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
			AudioSource.PlayClipAtPoint(explosion, transform.position);
			Destroy (other.gameObject);
			Destroy (gameObject);
			PlayerScore.playerScore += 10;
		} else if (other.tag == "Base")
			Destroy (gameObject);
	}
}