using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public Rigidbody2D rb; 

	Vector3 vel; 
	Vector3 p;

	public Transform firePoint;

	public float shootSpeed; 

	float velchange1;
	float velchange2; 
	float velchange3; 
	float velchange4; 
	float velchange5; 
	float velchange6; 

	public bool hitWall; 
	public bool hitRoof; 
	public bool hitsound; 
	bool hitTarget; 

	bool hitX; 
	bool hitY;

	float inactiveTimer; 

	public AudioSource audioSource; 
	public AudioClip hitWallSound; 

	void Start(){

		audioSource = GetComponent<AudioSource> (); 

		//Gets the rigidbody of the bullet
		rb.GetComponent<Rigidbody2D> ();

		//Input.mousePosition is local, this code changes it to World Point
		p = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		//Creates the velocity by getting the world point position of the mouse - the position of the bullet multiplied by the bullet speed
		vel = ((Vector2)p - (Vector2)transform.position).normalized * shootSpeed;

//		velchange1 = (shootSpeed * .9f);
//
//		velchange2 = (shootSpeed * .7f);
//
//		velchange3 = (shootSpeed * .5f); 
//
//		velchange4 = (shootSpeed * .35f);
//
//		velchange5 = (shootSpeed * .2f); 
//
//		velchange6 = (shootSpeed * .18f);

		shootSpeed = shootSpeed * 0.7f;

		velchange1 = shootSpeed;

		velchange2 = shootSpeed;

		velchange3 = shootSpeed; 

		velchange4 = shootSpeed;

		velchange5 = shootSpeed; 

		velchange6 = shootSpeed;

		gameObject.layer = LayerMask.NameToLayer("Gun");

		inactiveTimer = 0f; 
	}


	// Update is called once per frame
	void FixedUpdate () {

		inactiveTimer += 1f; 
		if (inactiveTimer > 2f) {
			gameObject.layer = LayerMask.NameToLayer ("Bullet");
		}

		//Goes into the Gun script and makes the script usuable in the bullet script
		GameObject gun = GameObject.Find ("Gun");
		Gun gunscript = gun.GetComponent<Gun> ();

		float thisBulletSpeed = vel.magnitude;
		float desiredSpeed = 0;
		//Switch gets the bulletcount from the Gun script and makes a case for each number of bullets
		switch (gunscript.bulletCount) {
			case 6: 
				desiredSpeed = thisBulletSpeed; 
				break;
			case 5:
				desiredSpeed = velchange1;
				break;
			case 4:
				desiredSpeed = velchange2;
				break;
			case 3: 
				desiredSpeed = velchange3;
				break;
			case 2: 
				desiredSpeed = velchange4;
				break;
			case 1: 
				desiredSpeed = velchange5;
				break;
			case 0:
				desiredSpeed = velchange6;
				break;
		}

		//move the current speed to the desired speed
		float newSpeed = Mathf.Lerp(thisBulletSpeed,desiredSpeed,0.1f);//10% of the way to the desired speed
		vel = vel.normalized * newSpeed; //scale vector to new desired speed;

		//If a wall was hit, reverse the x velocity
		if (hitWall) {
			audioSource.PlayOneShot (hitWallSound);
			vel.x *= -1f;
			hitWall = false;
		}

		//If the roof was hit, reverse the y velocity
		if (hitRoof) {
			audioSource.PlayOneShot (hitWallSound); 
			vel.y *= -1f; 
			hitRoof = false;
		}

		//If bullet has hit a target, then add 1 bullet to the bulletcount and destroy the bullet
		if (hitTarget) {
			gunscript.bulletCount += 1; 
			Destroy (gameObject);
		}
			
		//If the bullet is hit with a hitboxX, play the hit sound and reverse the x direction the bullet is heading
		if (hitX) {
			audioSource.PlayOneShot (hitWallSound); 
			vel.x *= -1f; 
			hitX = false;
		}

		//If the bullet is hit with a hitboxY, play the hit sound and reveerse the y direction the bullet is heading
		if (hitY) {
			audioSource.PlayOneShot (hitWallSound); 
			vel.y *= -1f; 
			hitY = false;
		}

		//If the bullet goes out of bounds and its x position is greater than 10 or less than -10, then destroy it
		if (transform.position.x > 10 || transform.position.x < -10) {
			gunscript.bulletCount += 1; 
			Destroy (gameObject);
		}

		//Constantly changes the position according to the intial velocity made at start
		transform.position += vel; 
	}

	void OnCollisionEnter2D(Collision2D coll){

		if (coll.gameObject.tag == "Wall") {
			hitWall = true;
		}

		if (coll.gameObject.tag == "Roof") {
			hitRoof = true;
		}

		if (coll.gameObject.tag == "Target") {
			hitTarget = true;
		}

		if (coll.gameObject.tag == "HitboxX") {
			hitX = true; 
		}

		if (coll.gameObject.tag == "HitboxY") {
			hitY = true; 
		}
	}

}
