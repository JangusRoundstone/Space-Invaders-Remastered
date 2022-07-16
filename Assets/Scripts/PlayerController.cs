using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Transform player;
	public float speed;
	public float maxBoundX, minBoundX, maxBoundY, minBoundY;
	public GameObject shot;
	public Transform ammoHolder;
	public Transform middleCannonPosition;
	public Transform rightCannonPosition;
	public Transform leftCannonPosition;
	public float fireRate;
	private float nextFire;
	private AudioSource laser;
	public Renderer render;
    public Color colour;
	public Animator animator;
	public Healthbar playerHealthBar;
	private PlayerLives playerLives;

	// Use this for initialization
	void Start () {
		player = GetComponent<Transform> ();
		laser = GetComponent<AudioSource> ();
		render = GetComponent<Renderer>();
		colour = render.material.color;
		playerLives = FindObjectOfType<PlayerLives>();
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
			Instantiate (shot, middleCannonPosition.position, middleCannonPosition.rotation);
			if (ammoHolder.childCount == 1) {
				Instantiate(shot, rightCannonPosition.position, rightCannonPosition.rotation);
			}
			if (ammoHolder.childCount == 0) {
				Instantiate(shot, rightCannonPosition.position, rightCannonPosition.rotation);
				Instantiate(shot, leftCannonPosition.position, leftCannonPosition.rotation);
			}
			if (laser != null)
			{
				laser.Play();
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "EnemyBullet") {
			playerHealthBar.SetHealth(playerLives.lives);
		}
	}


}