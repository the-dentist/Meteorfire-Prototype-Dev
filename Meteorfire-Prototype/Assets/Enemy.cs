using UnityEngine;

public class Enemy : Unit {
	protected Rigidbody2D rb;
	protected EnemyController ec;
	protected EnemyXPManager expm;
	protected PlayerXPManager pxpm;

	protected GameObject target;
	public float aggrorange;

	public void Start () {
		rb = GetComponent<Rigidbody2D> ();
		GameObject go = GameObject.FindGameObjectWithTag ("EnemyController");
		ec = go.GetComponent<EnemyController> ();
		expm = go.GetComponent<EnemyXPManager>();
		pxpm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerXPManager>();
		determineTarget ();
	}
		
	// TODO create a script that works for both turrets and enemies
	// to automatically attack opponents

	protected void determineTarget() {
		target = GameObject.FindGameObjectWithTag("Player");
	}

	public override void getKilled(Unit killer) {
		expm.gainXP (killer, this);
		pxpm.gainXP (killer, this);
		die ();
	}

	public virtual int getXPValue() {
		return ec.getDifficulty ();
	}

	public void Update () {
		//if the player is close enough then run towards him at variable speed
		if (Vector2.Distance (gameObject.transform.position, target.transform.position) < aggrorange) {
			rb.position = Vector2.MoveTowards (gameObject.transform.position, target.transform.position, maxspeed * Time.deltaTime);
			//rotate towards player
			transform.rotation = Quaternion.LookRotation (Vector3.forward, target.transform.position - transform.position);
		}
	}
}
			