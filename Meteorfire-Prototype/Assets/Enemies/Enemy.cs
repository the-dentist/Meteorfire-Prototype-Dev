using UnityEngine;
using UnityEditor;

public class Enemy : Unit {
	protected EnemyController ec;
	protected EnemyXPManager expm;
	protected GameObject player;

	[SerializeField]
	protected float aggrorange;

	public override void Awake () {
		GameObject enemyController = GameObject.FindGameObjectWithTag ("EnemyController");
		ec = enemyController.GetComponent<EnemyController> ();
		expm = enemyController.GetComponent<EnemyXPManager> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		base.Awake ();
	}
		
	protected virtual void determineTarget() {
		if (Vector2.Distance (transform.position, player.transform.position) <= aggrorange) {
			target = player;
		} else {
			target = null;
		}
	}

	public override void getKilled(Unit killer) {
		expm.gainXP (killer, (Unit)this);

		Player p = player.GetComponent<Player> ();
		p.gainXP (killer, this);
		p.awardGold (ec.determineGoldValue (this));

		die ();
	}
}
			