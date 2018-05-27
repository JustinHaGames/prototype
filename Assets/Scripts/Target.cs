using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

	float timer; 
	float mxTime;

	public bool bulletHit; 
	public bool hitboxHit;

	public GameObject particles; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GameObject gun = GameObject.Find ("Gun");
		Gun gunscript = gun.GetComponent<Gun> ();

		timer += Time.deltaTime;

		switch (gunscript.bulletCount) {
		case 6: 
			mxTime = 1f; 
			break; 
		case 5:
			mxTime = 1.5f; 
			break;
		case 4:
			mxTime = 2f; 
			break;
		case 3: 
			mxTime = 2.5f; 
			break;
		case 2: 
			mxTime = 3.5f; 
			break;
		case 1: 
			mxTime = 5f; 
			break;
		case 0:
			mxTime = 7f; 
			break;
		}

		if (timer > mxTime) {
			Destroy (gameObject);
		}

		if (bulletHit) {
			Instantiate (particles, transform.position, Quaternion.identity); 
			Destroy (gameObject); 
		}

		if (hitboxHit) {
			Instantiate (particles, transform.position, Quaternion.identity); 
			Destroy (gameObject); 
		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Bullet") {
			bulletHit = true; 
		}

		if (coll.gameObject.tag == "HitboxX") {
			hitboxHit = true; 
		}

		if (coll.gameObject.tag == "HitboxY") {
			hitboxHit = true; 
		}
	}
}
