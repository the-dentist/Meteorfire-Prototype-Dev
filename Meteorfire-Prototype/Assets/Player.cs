using UnityEngine;

public class Player : Unit {
	protected Rigidbody2D rb;

	[SerializeField]
	protected int gold = 50;
	[SerializeField]
	protected int bonusMaxspeed = 0;
	[SerializeField]
	protected int awardGoldMultiplier = 100;
	[SerializeField]
	protected float respawn_time = 20;

	public override void Awake () {
		rb = GetComponent<Rigidbody2D> ();
		base.Awake ();
	}
		
	public void awardGold(int value) { gold += value; }
	public void spendGold(int value) { gold -= value; }
	public bool hasGold(int value) { return gold >= value; }

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

	public void Update() {
		Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);

		Vector2 speedInput = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));
		rb.velocity = speedInput * moveSpeed;
	}
}
	