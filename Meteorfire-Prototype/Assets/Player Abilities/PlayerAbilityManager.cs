using UnityEngine;

public class PlayerAbilityManager : MonoBehaviour {
	protected PlayerAbility[] selectedAbilities;
	protected int abilitySlotMaximum;

	public void upgradeAbility(string abilityName) {
		Player player = GetComponent<Player> ();
		PlayerAbility[] abilities = GetComponents<PlayerAbility> ();

		foreach (PlayerAbility pa in abilities) {
			if (pa.abilityName == abilityName && pa.getLevel() < 3) {
				int cost = pa.getUpgradeCost ();
				if (player.hasGold (cost)) {
					player.spendGold (cost);
					pa.levelUp ();
					break;
				}
			}
		}
	}
}
	