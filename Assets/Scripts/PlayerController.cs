using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Transform player;
	public float speed;
	public float maxBoundX, minBoundX, maxBoundY, minBoundY;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;

	private float nextFire;
	private AudioSource laser;

	// Use this for initialization
	void Start () {
		player = GetComponent<Transform> ();
		laser = GetComponent<AudioSource> ();
	}

	void FixedUpdate () {
		float h = Input.GetAxis ("Horizontal");

		if (player.position.x < minBoundX && h < 0)
			h = 0;
		else if (player.position.x > maxBoundX && h > 0)
			h = 0;

		player.position += Vector3.right * h * speed;
		
		float v = Input.GetAxis("Vertical");

		if (player.position.y < minBoundY && v < 0) 
		    v = 0;
		else if (player.position.y > maxBoundY && v > 0)
		    v = 0;

		player.position += Vector3.up * v * speed;
	}

	void Update(){
		if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0)) && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			if (laser != null)
			{
				laser.Play();
			}
			//laser.Play();
			if (!GameManager.playGame)
				GameManager.playGame = true; 
		}
	}

}