using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHandler : MonoBehaviour {

	public Vector3 direction;

	public float bulletSpeed;

	private int lifeTimer = 0; 

	// Use this for initialization
	void Start () {
		direction = (GameObject.Find("Player").transform.position - transform.position).normalized; // find a path toward the player's position
	}

	// Update is called once per frame
	void Update() {
		transform.position += direction * bulletSpeed * Time.deltaTime; //move bullet toward the player's position

		lifeTimer += 1; 

		if (lifeTimer >= 300)
		{
			Destroy (gameObject);
		}

		if (transform.position.x >= 20 || transform.position.y >= 15 || transform.position.x <= -20 || transform.position.y <= -15)
		{
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "HitboxX" || col.gameObject.tag == "Wall")
		{
			direction.x *= -1;
		}

		if (col.gameObject.tag == "HitboxY" || col.gameObject.tag == "Roof")
		{
			direction.y *= -1; 
		}

		if (col.gameObject.tag == "Player")
		{
			//TODO: handle player's death/damage or handle this elsewhere
		}
	}
}
