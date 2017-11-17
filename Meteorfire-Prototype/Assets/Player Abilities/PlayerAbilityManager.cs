using UnityEngine;

public class PlayerAbilityManager : MonoBehaviour {
	protected PlayerAbility[] abilities;
	protected PlayerAbility[] selectedAbilities;
	protected int abilitySlotMaximum;
	protected Player player;

	public void Awake() {
		abilities = GetComponents<PlayerAbility> ();
		player = transform.parent.gameObject.GetComponent<Player> ();
	}

	public void Update() {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			GetComponent<BlinkAbility> ().effect ();
		}
	}

	public void upgradeAbility(string abilityName) {
		Player player = transform.parent.gameObject.GetComponent<Player> ();

		foreach (PlayerAbility pa in abilities) {
			if (pa.abilityName == abilityName && pa.getLevel() < PlayerAbility.maxLevel) {
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
	