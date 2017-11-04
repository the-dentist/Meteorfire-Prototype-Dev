using UnityEngine;

// This class is intended to be attached to the player object
// this class manages the player's XP gains 
public class PlayerXPManager : XPManager {
	protected Player player;

	public void start() {
		player = gameObject.GetComponent<Player> ();
		current_xp = 0;
		required_xp = determineRequiredXP ();
	}

	protected override void levelUp() {
		player.levelUp ();
	}

	protected override void determineXPGain(Unit source, Unit victim) {
		// TODO LATER determine xp based off of specific enemy type 
		// if specific enemy types are ever included

		if (source.tag == "Player") {
			gainXP(2);
		} else if (source.tag == "Turret") {
			gainXP(1);
		}
	}

	protected override int determineRequiredXP() {
		return player.getLevel();
	}
}
