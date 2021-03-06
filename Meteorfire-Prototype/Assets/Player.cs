using UnityEngine;

public class Player : Unit {
//	PlayerHotkeys hotkeys;
	PlayerXPManager pxpm;

	[SerializeField]
	protected int gold = 50;
	[SerializeField]
	protected int awardGoldMultiplier = 100;
	[SerializeField]
	protected float respawn_time = 20f;

	public override void Awake() {
		pxpm = GetComponent<PlayerXPManager> ();
//		hotkeys = GetComponent<PlayerHotkeys> ();

		base.Awake ();
	}

	public override void Update() {
		Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
		move(new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical")));
	}

	public void awardGold(int value) { gold += value; }
	public void spendGold(int value) { gold -= value; }
	public bool hasGold(int value) { return gold >= value; }

	public void gainXP (Unit Killer, Unit victim) {
		pxpm.gainXP (Killer, victim);
	}

	public override void levelUp() { 
		awardGold(level * awardGoldMultiplier);
		base.levelUp ();
	}

	public override void getKilled(Unit killer) { 
		die ();
	}

	public override void die() {
		//player death goes here
	}


}
	