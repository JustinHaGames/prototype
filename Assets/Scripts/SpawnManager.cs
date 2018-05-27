using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

	public GameObject Target; 

	public GameObject gm; 

	public float xPos; 
	public float yPos; 

	// Use this for initialization
	void Start () {
		xPos = Random.Range (-7.46f, 7.49f);
		yPos = Random.Range (-4f, 4.4f);

		Vector2 spawnPos = new Vector2 (xPos, yPos);

		Instantiate (Target, spawnPos, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {

			xPos = Random.Range (-7.46f, 7.49f);
			yPos = Random.Range (-4f, 4.4f);

			Vector2 spawnPos = new Vector2 (xPos, yPos);
			if (GameObject.FindGameObjectWithTag ("Target") == null) {
					Instantiate (Target, spawnPos, Quaternion.identity);
			}
		}
}
