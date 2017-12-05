using UnityEngine;

// this class manages the player's XP gains 
public class PlayerXPManager : XPManager {
	protected Player player;

	public void Awake() {
		player = GetComponent<Player>();
	}

	protected override void levelUp() {
		player.levelUp ();
	}

	protected override void updateRequiredXP() {
		requiredXP = player.getLevel();
	}

	public override void gainXP (Unit killer, Unit victim) {
		float xp = GameObject.FindGameObjectWithTag("EnemyController").GetComponent<EnemyController>().determineXPValue(victim);

		// gain bonus xp for killing the enemy yourself
		if (killer.tag == "Player") xp *= 1.5f;

		currentXP += xp;
		updateRequiredXP ();

		while (currentXP >= requiredXP) {
			currentXP -= requiredXP;
			levelUp();
			updateRequiredXP ();
		}
	}
}
