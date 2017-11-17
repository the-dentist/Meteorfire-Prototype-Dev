using UnityEngine;

public class Player : Unit {
	protected MovementManager mm;
	protected PlayerXPManager pxm;

	new public void Awake() {
		mm = GetComponent<MovementManager> ();
		pxm = GetComponent<PlayerXPManager> ();
		base.Awake ();
	}

	public void FixedUpdate() {
		// rotate to face crosshairs
		Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);

		move ();
	}

	[SerializeField]
	protected int gold, awardGoldMultiplier, hpPerLevel;

	[SerializeField]
	public float respawnTime;
		
	public void awardGold(int value) { gold += value; }
	public void spendGold(int value) { gold -= value; }
	public bool hasGold(int value) { return gold >= value; }

	protected void move() {
		// sum movement vectors
		float movex = Input.GetAxis ("Horizontal");
		float movey = Input.GetAxis ("Vertical");
		mm.move (new Vector2 (movex, movey));
	}

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

	public void awardKill(Unit killer, float xp, int gold) {
		pxm.gainXP (killer, xp);
		awardGold (gold);
	}
}
	