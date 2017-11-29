using UnityEngine;

// this class manages the xp progress of the enemy controller
public class EnemyXPManager : XPManager {
	protected EnemyController ec;

	public void Awake() {
		ec = GetComponent<EnemyController> ();
	}

	protected override void levelUp() {
		ec.levelUp ();
	}
		
	protected override void updateRequiredXP() {
		requiredXP = ec.getDifficulty () * 10;
	}

	public override void gainXP (Unit killer, Unit victim) {
		currentXP += ec.determineXPValue(victim);
		while (currentXP >= requiredXP) {
			currentXP -= requiredXP;
			levelUp();
			updateRequiredXP ();
		}
	}
}
