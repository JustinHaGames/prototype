using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour {

	public GameObject hitboxRight;
	public GameObject hitboxLeft; 
	public GameObject hitboxUp; 
	public GameObject hitboxDown; 

	bool canAttack;

	// Use this for initialization
	void Start () {
		canAttack = true;
	}
	
	// Update is called once per frame
	void Update () {

		if ((Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.LeftShift)) || (Input.GetKeyDown(KeyCode.RightArrow))  && canAttack == true) {
			hitboxRight.SetActive (true);
			canAttack = false;
			StartCoroutine (HitboxActive ());
		}

		if ((Input.GetKey(KeyCode.A) && Input.GetKeyDown(KeyCode.LeftShift)) || (Input.GetKeyDown(KeyCode.LeftArrow)) && canAttack == true) {
			hitboxLeft.SetActive (true);
			canAttack = false;
			StartCoroutine (HitboxActive ());
		}

		if ((Input.GetKey(KeyCode.W) && Input.GetKeyDown(KeyCode.LeftShift)) || (Input.GetKeyDown(KeyCode.UpArrow)) && canAttack == true) {
			hitboxUp.SetActive (true); 
			canAttack = false;
			StartCoroutine (HitboxActive ());
		}

		if ((Input.GetKey(KeyCode.S) && Input.GetKeyDown(KeyCode.LeftShift)) || (Input.GetKeyDown(KeyCode.DownArrow)) && canAttack == true) {
			hitboxDown.SetActive (true);
			canAttack = false;
			StartCoroutine (HitboxActive ());
		}
		
	}

	IEnumerator HitboxActive(){
		for (int i = 0; i < 8; i++) {
			yield return new WaitForFixedUpdate();
		}
		hitboxRight.SetActive (false);
		hitboxLeft.SetActive (false);
		hitboxUp.SetActive (false);
		hitboxDown.SetActive (false);
		canAttack = true;
	}
}
