using UnityEngine;
using System.Linq;

public class Turret : Unit {
	[SerializeField]
	protected Weapon w;

	[SerializeField]
	protected float maxRange = 20f;

	public void Awake() {
		w = GetComponent<Weapon> ();
	}

	public void Update () {
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
			if (dist <= maxRange && (closest == null || dist < minDist)) {
				closest = enemy;
				minDist = dist;
			}
		}

		target = closest;
	}
}

