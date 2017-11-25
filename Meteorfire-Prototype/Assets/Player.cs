using UnityEngine;
using UnityEditor;

public class Player : Unit {
	protected Rigidbody2D rb;
	protected int gold, bonusMaxspeed, bonusAcceleration;

	public int awardGoldMultiplier, hpPerLevel;
	public float respawn_time;

	void Start() {
		rb = GetComponent<Rigidbody2D> ();
		isMoveable = true;
		isVulnerable = true;
		isFriendly = true;
		isPickup = false;
		level = 1;
		gold = 50;
		maxhp = 100;
	}
		
	public void awardGold(int value) { gold += value; }
	public void spendGold(int value) { gold -= value; }
	public bool hasGold(int value) { return gold >= value; }

	public override void levelUp() { 
		awardGold(level * awardGoldMultiplier);
		level += 1;
		maxhp += hpPerLevel;
		GetComponent<HealthManager>().heal (hpPerLevel);
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
		rb.AddForce (new Vector2 (movex, movey) * baseAcceleration);

		// disallow speed greater than max speed
		if (rb.velocity.magnitude > maxspeed) {
			rb.velocity = rb.velocity.normalized * maxspeed;
		}

		//rotate to mouse position
		Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
	}

	[CustomEditor(typeof(Player),true)]
	public class PlayerEditor : Editor {
		public override void OnInspectorGUI() {
			Player player = target as Player;

			player.baseAcceleration = EditorGUILayout.IntSlider("Base Acceleration", player.baseAcceleration,-10,40);
			player.maxspeed = EditorGUILayout.IntSlider("Base Top Speed", player.maxspeed,-10,40);
			player.awardGoldMultiplier = EditorGUILayout.IntSlider("Award Gold Multiplier", player.awardGoldMultiplier, 1,100);
			player.hpPerLevel = EditorGUILayout.IntSlider("HP Per Level", player.hpPerLevel, 1,100);
			if (GUI.changed) {
				EditorUtility.SetDirty (target);
			}
		}
	}
}
	