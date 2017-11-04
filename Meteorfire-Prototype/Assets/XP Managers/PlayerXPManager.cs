using UnityEngine;

// this class manages the player's XP gains 
public class PlayerXPManager : XPManager {
	protected Player player;

	public override void start() {
		base.start ();
		player = GetComponent<Player>();
	}

	protected override void levelUp() {
		player.levelUp ();
	}

	protected override void update_required_xp() {
		required_xp = player.getLevel ();
	}

	public override void gainXP (Unit killer, Unit victim) {
		float xp = ((Enemy)victim).getXPValue ();

		// gain bonus xp for killing the enemy yourself
		if (killer.tag == "Player") xp *= 1.5f;

		current_xp += xp;
		update_required_xp ();

		while (current_xp >= required_xp) {
			current_xp -= required_xp;
			levelUp();
			update_required_xp ();
		}
	}
}
