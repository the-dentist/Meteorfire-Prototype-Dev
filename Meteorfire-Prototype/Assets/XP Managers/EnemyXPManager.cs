using UnityEngine;

// this class manages the xp progress of the enemy controller
public class EnemyXPManager : XPManager {
	protected EnemyController ec;

	public override void Start() {
		ec = GetComponent<EnemyController> ();
		base.Start ();
	}

	protected override void levelUp() {
		ec.levelUp ();
	}
		
	protected override void update_required_xp() {
		required_xp = ec.getDifficulty () * 10;
	}

	public override void gainXP (Unit killer, Unit victim) {
		current_xp += ec.determineXPValue(victim);
		while (current_xp >= required_xp) {
			current_xp -= required_xp;
			levelUp();
			update_required_xp ();
		}
	}
}
