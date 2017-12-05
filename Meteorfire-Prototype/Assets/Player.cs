using UnityEngine;

public class Player : Unit {
//	PlayerHotkeys hotkeys;
	PlayerXPManager pxpm;
	private Animator anim;

	[SerializeField]
	protected int gold = 50;
	[SerializeField]
	protected int awardGoldMultiplier = 100;
	[SerializeField]
	protected float respawn_time = 20f;

	protected int imageindex = 0;

	public override void Awake() {
		pxpm = GetComponent<PlayerXPManager> ();
//		hotkeys = GetComponent<PlayerHotkeys> ();
		anim = gameObject.GetComponent<Animator>();
		base.Awake ();
	}

	public override void Update() {
		Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		//transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
		move(new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical")));
		animate ();
	}

	void animate() {
		if (Input.GetKey (KeyCode.W)) {
		Debug.Log (imageindex);
		imageindex = 1;
	}
	if (Input.GetKey(KeyCode.A)){
			Debug.Log(imageindex);
			imageindex = 2;
}
	if (Input.GetKey(KeyCode.S)){
			Debug.Log(imageindex);
			imageindex = 1;
}
	if (Input.GetKey(KeyCode.D)){
			Debug.Log(imageindex);
			imageindex = 0;
}
		anim.SetInteger ("imageindex", imageindex);
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
	