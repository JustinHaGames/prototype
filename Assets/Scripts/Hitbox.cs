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
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerPos = Camera.main.WorldToScreenPoint(transform.position);
        float distX = Mathf.Abs(playerPos.x - mousePos.x);
        float distY = Mathf.Abs(playerPos.y - mousePos.y);
        if (distX > distY && Input.GetMouseButtonDown(0) && mousePos.x > playerPos.x && canAttack == true){//((Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.LeftShift)) || (Input.GetKeyDown(KeyCode.RightArrow))  && canAttack == true) {
            hitboxRight.SetActive (true);
			canAttack = false;
			StartCoroutine (HitboxActive ());
		}

		if (distX > distY && Input.GetMouseButtonDown(0) && mousePos.x < playerPos.x && canAttack == true){//((Input.GetKey(KeyCode.A) && Input.GetKeyDown(KeyCode.LeftShift)) || (Input.GetKeyDown(KeyCode.LeftArrow)) && canAttack == true) {
            hitboxLeft.SetActive (true);
			canAttack = false;
			StartCoroutine (HitboxActive ());
		}

		if (distX < distY && Input.GetMouseButtonDown(0) && mousePos.y > playerPos.y && canAttack == true){//((Input.GetKey(KeyCode.W) && Input.GetKeyDown(KeyCode.LeftShift)) || (Input.GetKeyDown(KeyCode.UpArrow)) && canAttack == true) {
            hitboxUp.SetActive (true); 
			canAttack = false;
			StartCoroutine (HitboxActive ());
		}

		if (distX < distY && Input.GetMouseButtonDown(0) && mousePos.y < playerPos.y && canAttack == true){//((Input.GetKey(KeyCode.S) && Input.GetKeyDown(KeyCode.LeftShift)) || (Input.GetKeyDown(KeyCode.DownArrow)) && canAttack == true) {
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
