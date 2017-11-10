using UnityEngine;

public class Weapon : MonoBehaviour {
	protected GameObject player;
	protected PlayerHotkeys hotkeys;
	protected float fireDelay;

	float lastFire;

	void Start () {
		player = GameObject.FindWithTag("Player");
		hotkeys = player.GetComponent<PlayerHotkeys> ();
	}

	public void Update () {
		gameObject.transform.position = player.transform.position;

		Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		transform.rotation = Quaternion.LookRotation (Vector3.forward, mousePos - transform.position); 
		Debug.Log ("primary = " + hotkeys.primaryFire.ToString ());
		if (Input.GetKeyDown (hotkeys.primaryFire)) {
			fire ();
		}
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