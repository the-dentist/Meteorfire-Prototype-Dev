using UnityEngine;

public class Weapon : MonoBehaviour {
	protected GameObject player;
	protected PlayerHotkeys hotkeys;

	[SerializeField]
	protected float fireDelay = 0;

	float lastFire;

	void Start () {
		player = GameObject.FindWithTag("Player");
		hotkeys = player.GetComponent<PlayerHotkeys> ();
	}

	public void Update () {
		if (Input.GetKeyDown(hotkeys.primaryFire)) fire ();
	}

	public void fire() {
		float now = Time.time;
		if (now - fireDelay >= lastFire) {
			lastFire = now;
			shoot ();
		}
	}

	public virtual void shoot() {}
}