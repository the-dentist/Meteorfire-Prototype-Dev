using UnityEngine;

// this class is intended to be attached to the enemy controller object
// this class manages the progress of the enemy controller
public class EnemyXPManager : XPManager {
	protected EnemyController ec;

	public void start() {
		ec = gameObject.GetComponent<EnemyController> ();
		current_xp = 0;
		required_xp = determineRequiredXP ();
	}

	protected override void levelUp() {
		ec.levelUp ();
	}
		
	protected override void determineXPGain(Unit source, Unit victim) {
		if (victim.tag == "Enemy") {
			gainXP(1);
		} else if (source.tag == "Boss") {
			gainXP(10);
		}
	}

	protected override int determineRequiredXP() {
		return ec.getLevel () * 10;
	}
}