using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

	public Camera mainCamera; 

	public GameObject bullet; 
	GameObject shotBullet; 

	public Transform Firepoint;

	public int bulletCount;

	public bool shot; 
	public bool shotsound; 

	public bool reload; 
	public bool reloadSound; 

	public List<GameObject> bulletList = new List <GameObject>();  

	// Use this for initialization
	void Start () {
		bulletCount = 6;
	}
	
	// Update is called once per frame
	void Update (){
		//If the left click on the mouse is pressed, shot becomes true instantiating a bullet
		if (Input.GetMouseButtonDown (0) && bulletCount != 0) {		
			mainCamera.SendMessage ("shake", null, SendMessageOptions.DontRequireReceiver); 	
			shot = true; 
		}
		//If the right click on the mouse or R is pressed, then reloading becomes true
		if ((Input.GetMouseButtonDown (1) && bulletCount != 6) || Input.GetKeyDown(KeyCode.R) && bulletCount != 6) {
			reload = true;
		}

		//Get the Screen positions of the object
		Vector2 positionOnScreen = Camera.main.WorldToViewportPoint (transform.position);

		//Get the Screen position of the mouse
		Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint (Input.mousePosition);

		//Get the angle between the points
		float angle = AngleBetweenTwoPoints (positionOnScreen, mouseOnScreen);

		//Ta Daaa
		transform.rotation = Quaternion.Euler (new Vector3 (0f, 0f, angle));
	}

	void FixedUpdate(){
		//If left click is true and player has bullets, then spawn a bullet at the Firepoint and subtract 1 bullet from chamber
		if (shot == true && bulletCount > 0) {
			shotsound = true; 
			shotBullet = Instantiate (bullet,Firepoint.position, transform.rotation);
			bulletList.Add (shotBullet);
			bulletCount -= 1;
			shot = false;
		}

		//Gun can only hold six bullets
		if (bulletCount >= 6) {
			bulletCount = 6;
		}

		//Can't have less than 0 bullets
		if (bulletCount <= 0) {
			bulletCount = 0;
		}

		//If you reloaded, add one bullet to the chamber and destroy the first bullet that was shot outb
		if (reload == true) {
			bulletCount += 1;
			reloadSound = true; 
			Destroy (bulletList [0]);
			bulletList.RemoveAt (0);
			reload = false;
		}

		//Gets the size of the bulletList arraylist
		int size = bulletList.Count; 

//		//This forloop will look through all of the bullets in bulletList and see if any come back as false. If one does, it removes that slot from the bulletList
//		for (int i = 0; i < size; i++){
//			Debug.Log ("i = " + i);
//			Debug.Log ("size = " + size);
//			if (bulletList[i] != true){
//				bulletList.RemoveAt(i); 
//
//			}
//		}

		int x = 0;
		while (x < bulletList.Count) {
			if (bulletList[x] != true){
				bulletList.RemoveAt(x); 
			}
			x++;
		}

	}

	float AngleBetweenTwoPoints (Vector3 a, Vector3 b)
	{
		return Mathf.Atan2 (a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
	}
		

}
