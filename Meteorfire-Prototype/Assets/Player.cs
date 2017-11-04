using UnityEngine;

public class Player : Unit {
	protected Rigidbody2D rb;

	void Start() {
		rb = GetComponent<Rigidbody2D> ();
		level = 1;
	}

	public override void getKilled(Unit killer) { 
		die ();
	}

	public override void die() {
		//player death goes here
	}

	// handle player movevemt
	void FixedUpdate() {
		// sum movement vectors into vector2 and apply to rigid body
		float movex = Input.GetAxis ("Horizontal");
		float movey = Input.GetAxis ("Vertical");
		rb.AddForce (new Vector2 (movex, movey) * movespeed);

		// disallow speed greater than max speed
		if (rb.velocity.magnitude > maxspeed) {
			rb.velocity = rb.velocity.normalized * maxspeed;
		}

		//rotate to mouse position
		Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
	}
}