using UnityEngine;
using UnityEditor;

public class Enemy : Unit {
	protected Rigidbody2D rb;
	protected GameObject enemy_controller;
	protected GameObject player;

	protected GameObject target;

	[SerializeField]
	protected float aggrorange;

	public void Start () {
		rb = GetComponent<Rigidbody2D> ();
		isMoveable = true;
		isFriendly = false;
		isVulnerable = true;
		isPickup = false;
		enemy_controller = GameObject.FindGameObjectWithTag ("EnemyController");
		player = GameObject.FindGameObjectWithTag ("Player");

		/*
		 * max hp = ???
		 * attack damage = ???
		 */

		determineTarget ();
	}
		
	// TODO create a script that works for both turrets and enemies
	// to automatically attack opponents

	protected virtual void determineTarget() {
		target = player;
	}

	public override void getKilled(Unit killer) {
		enemy_controller.GetComponent<EnemyXPManager>().gainXP (killer, (Unit)this);
		player.GetComponent<PlayerXPManager>().gainXP (killer, this);
		player.GetComponent<Player> ().awardGold (enemy_controller.GetComponent<EnemyController> ().determineGoldValue (this));
		die ();
	}

	public void Update () {
		//if the player is close enough then run towards him at variable speed
		if (Vector2.Distance (gameObject.transform.position, target.transform.position) < aggrorange) {
			rb.position = Vector2.MoveTowards (gameObject.transform.position, target.transform.position, moveSpeed * Time.deltaTime);
			//rotate towards player
			transform.rotation = Quaternion.LookRotation (Vector3.forward, target.transform.position - transform.position);
		}
	}
}
			