using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {

	private int frame = 0;

	public Transform Player; // player
	public GameObject bulletPrefab;

	private int firedAtFrame = 0;

	private Vector3 direction;

	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update () {

		frame++;
		Debug.Log (frame);
		Vector3 offset = new Vector3 (.8f, 0f, 0f);
		if (frame % 60 == 0) // fire shots every 5 seconds
		{
			Instantiate(bulletPrefab, transform.localPosition + offset, transform.rotation); //create bullet
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Bullet" || col.gameObject.tag == "EnemyBullet")
		{
			Destroy (gameObject);
			//TODO: handle player's death/damage or handle this elsewhere
		}
	}

}