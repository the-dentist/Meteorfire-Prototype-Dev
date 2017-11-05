using UnityEngine;

public class PlayerAbilityManager : MonoBehaviour {
	protected PlayerAbility[] abilities;
	protected PlayerAbility[] selectedAbilities;
	protected int abilitySlotMaximum;

	public void Start () {
		abilities = new PlayerAbility[] {
			new BlinkAbility (),
			new HasteAbility (),
			new BigBoltAbility (),
			new MiasmaAbility (),
			new RejuvinationAbility (),
			new JudgementAbility (),
			new ForcePulseAbility (),
			new HypershieldAbility ()
		};
	}

	public void upgradeAbility(string abilityName) {
		Player player = GetComponent<Player> ();
		foreach (PlayerAbility pa in abilities) {
			if (pa.getName() == abilityName && pa.getLevel() < 3) {
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
	