using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class NSMMovement : MonoBehaviour {

	public Rigidbody2D rb;
	public BoxCollider2D box;

	Vector2 vel; 

	public float accel; 
	public float mxAccel; 

	public float gravity; 

	public float jumpSpd; 

	bool grounded;

	public bool playerDead; 

	Vector2[] debugPts;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();

		box = GetComponent<BoxCollider2D>();

		debugPts = new Vector2[2];

	}

	private void FixedUpdate () {

		Vector3 theScale = transform.localScale;
		//Calls the SetGrounded fuction to see if the player is grounded every frame
		SetGrounded ();
		// Right and left are only true if their respective arrow keys are pressed
		bool right = Input.GetKey(KeyCode.D);
		bool left = Input.GetKey(KeyCode.A);
		bool up = Input.GetKey(KeyCode.W);
		bool down = Input.GetKey(KeyCode.S);

		accel = accel * 3;

		// If right arrow key is pressed, then the velocity will increase by the acceleration wanted
		if (right == true) {
			vel.x = accel; 
		}

		// If left arrow key is pressed, then the velocity will increase by the negative of the acceleration wanted
		if (left == true) {
			vel.x = -accel; 
		}

		// If neither arrow key is pressed, then the player won't move
		if (!right && !left) {
			vel.x = 0; 
		}

		// This ONE line of code sets the vel.x to the max and min if they go over
		vel.x = Mathf.Max (Mathf.Min (vel.x, mxAccel), -mxAccel);

		// This code allows the player to move according to the buttons pressed

		//If the player is not grounded, apply gravity
		if (up == true) {
			vel.y = accel; 
		}if (down == true) {
			vel.y = -accel; 
		}
		if (!up && !down) {
			vel.y = 0; 
		}

		vel.y = Mathf.Max (Mathf.Min (vel.y, mxAccel), -mxAccel);


		rb.MovePosition ((Vector2)transform.position + vel); 

	}

	void SetGrounded(){

		Vector2 pt1 = transform.TransformPoint(box.offset + new Vector2(box.size.x / 2, -box.size.y / 2));//(box.size / 2));
		Vector2 pt2 = transform.TransformPoint(box.offset - (box.size / 2) + new Vector2(0, 0));
		grounded = Physics2D.OverlapArea(pt1, pt2, LayerMask.GetMask("Floor")) != null;
		debugPts[0] = pt1;
		debugPts[1] = pt2;

		if (grounded) {
			vel.y = 0;
		}
	}

	void OnCollisionEnter2D (Collision2D coll){
		if (coll.gameObject.tag == "Bullet") {
			playerDead = true; 
		}
	}
}
