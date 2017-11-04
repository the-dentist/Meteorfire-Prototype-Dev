using UnityEngine;

// the XP class is attached to a gameobject (player, enemycontroller, etc) 
// it determines how much xp is granted for a kill
// it also tracks xp progress and updates the attached object's level
abstract public class XPManager : MonoBehaviour {
	protected int current_xp;
	protected int required_xp;

	protected abstract void levelUp ();

	protected void gainXP(int value) {
		current_xp += value;
		while (current_xp >= required_xp) {
			current_xp -= required_xp;
			levelUp();
			required_xp = determineRequiredXP ();
		}
	}

	protected abstract void determineXPGain (Unit source, Unit victim);
	protected abstract int determineRequiredXP ();

	void OnEnable()  { EventManager.signalKill += determineXPGain; }
	void OnDisable() { EventManager.signalKill -= determineXPGain; }
}