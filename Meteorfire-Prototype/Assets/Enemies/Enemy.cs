using UnityEngine;
using System.Linq;

public class Enemy : Unit {
	protected EnemyController ec;
	protected EnemyXPManager expm;
	protected GameObject player;
	protected Weapon w;

	[SerializeField]
	protected float aggrorange;

	public override void Awake () {
		GameObject enemyController = GameObject.FindGameObjectWithTag ("EnemyController");
		ec = enemyController.GetComponent<EnemyController> ();
		expm = enemyController.GetComponent<EnemyXPManager> ();
		w = GetComponent<Weapon> ();

		player = GameObject.FindGameObjectWithTag ("Player");
		base.Awake ();
	}
		
	protected virtual void determineTarget() {
		if (Vector2.Distance (transform.position, player.transform.position) <= aggrorange) {
			target = player;
		} else {
			// try to find closest structure in range
			GameObject[] structures = GameObject.FindGameObjectsWithTag ("Wall").Concat(GameObject.FindGameObjectsWithTag ("Turret")).ToArray().Concat(GameObject.FindGameObjectsWithTag ("Ship")).ToArray();
			

			float minDist = 0;
			GameObject closest = null;

			foreach (GameObject structure in structures) {
				float dist = Vector2.Distance (transform.position, structure.transform.position);
				if (dist < aggrorange && (closest == null || dist < minDist)) {
					closest = structure;
					minDist = dist;
				}
			}

			target = closest;
		}
	}

	public override void Update () {
		if (target == null)
			determineTarget ();

		if (target != null) {
			float targetDistance = Vector2.Distance (target.transform.position, transform.position);

			if (targetDistance > aggrorange) {
				target = null;
			} else if (targetDistance < w.getRange ()) {
				w.fire (this, target.transform.position);
			} else {
				move (target.transform.position - transform.position);
			}

		} else {
			move (transform.position * -1);
		}
	}

	public override void getKilled(Unit killer) {
		Debug.Log (unitName + " Killed by " + killer.unitName); 

		expm.gainXP (killer, (Unit)this);

		Player p = player.GetComponent<Player> ();
		p.gainXP (killer, this);
		p.awardGold (ec.determineGoldValue (this));

		die ();
	}

	public void OnControllerColliderHit(ControllerColliderHit col) {
		string colTag = col.gameObject.tag;
		if (colTag == "Player" || colTag == "Wall" || colTag == "Turret" || colTag == "Ship") {
			target = col.gameObject;
		}
	}
}
			