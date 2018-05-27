using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDestroyer : MonoBehaviour {

	float timer; 

	// Use this for initialization
	void Start () {
		timer = 2f; 
	}
	
	// Update is called once per frame
	void Update () {
		timer -= 1f * Time.deltaTime; 
		if (timer <= 0f) {
			Destroy (gameObject);
		}
	}
}
