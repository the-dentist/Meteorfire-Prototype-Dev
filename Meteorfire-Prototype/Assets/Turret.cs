using UnityEngine;
using System.Linq;

public class Turret : Unit {
	protected Weapon w;

	public override void Awake() {
		w = GetComponent<Weapon> ();
		Physics.IgnoreLayerCollision(8, 9);
		base.Awake ();
	}

	public override void Update () {
		targetClosestEnemy ();
		if (target != null) {
			w.fire (this, target.transform.position);
		}
	}

	void targetClosestEnemy() {
		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy").Concat(GameObject.FindGameObjectsWithTag("Boss")).ToArray();

		float minDist = 0;
		GameObject closest = null;

		foreach (GameObject enemy in enemies) {
			float dist = Vector2.Distance (transform.position, enemy.transform.position);
			if (dist < w.getRange() && (closest == null || dist < minDist)) {
				closest = enemy;
				minDist = dist;
			}
		}

		target = closest;
	}
}

