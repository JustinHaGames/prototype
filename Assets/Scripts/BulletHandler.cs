using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHandler : MonoBehaviour {

	public Vector3 direction;
	public bool isReflected = false;

	public float bulletSpeed;

	// Use this for initialization
	void Start () {
		direction = (GameObject.Find("Player").transform.position - transform.position).normalized; // find a path toward the player's position
	}

	// Update is called once per frame
	void Update() {
		transform.position += direction * bulletSpeed * Time.deltaTime; //move bullet toward the player's position

		if (transform.position.x >= 20 || transform.position.y >= 15 || transform.position.x <= -20 || transform.position.y <= -15)
		{
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "HitboxX" || col.gameObject.tag == "HitboxY")
		{
			bool isDash = GameObject.Find("Player").GetComponent<NSMMovement>().isDashing;
			//if (isDash)
			//{
				direction = -direction;
				isReflected = true;
			//}
			//else
			//{
				//Destroy(gameObject);
			//}
		}
		if (col.gameObject.tag == "Player")
		{
			//TODO: handle player's death/damage or handle this elsewhere
		}
	}
}
