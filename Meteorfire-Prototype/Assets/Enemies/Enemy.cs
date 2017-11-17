using UnityEngine;

public class Enemy : Unit {
	protected MovementManager mm;
	protected Unit target;

	new public void Awake() {
		mm = GetComponent<MovementManager> ();
		base.Awake ();
	}

	public void Update () {
		determineTarget ();
		Vector3 targetLocation = target.gameObject.transform.position;

		// rotate to face target
		transform.rotation = Quaternion.LookRotation(Vector3.forward,  targetLocation - transform.position);

		mm.move (targetLocation - transform.position);
	}

	[SerializeField]
	protected float aggrorange;

	protected virtual void determineTarget() {
		target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
	}

	public override void getKilled(Unit killer) {
		GameObject.FindGameObjectWithTag ("EnemyController").GetComponent<EnemyController>().logKill(killer, this);
		die ();
	}
}
			