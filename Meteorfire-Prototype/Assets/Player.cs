using UnityEngine;

public class Player : Unit {
	protected Rigidbody2D rb;
	protected int gold;

	public int award_gold_multiplier, hp_per_level;
	public float respawn_time;

	void Start() {
		rb = GetComponent<Rigidbody2D> ();
		level = 1;
		gold = 50;
	}
		
	public void awardGold(int value) { gold += value; }
	public void spendGold(int value) { gold -= value; }

	public override void levelUp() { 
		awardGold(level * award_gold_multiplier);
		level += 1;
		maxhp += hp_per_level;
		GetComponent<HealthManager>().heal (hp_per_level);
	}

	public override void getKilled(Unit killer) { 
		die ();
	}

	public override void die() {
		//player death goes here
	}

	// handle player movevent
	// TODO? make into actual player_movement class?
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