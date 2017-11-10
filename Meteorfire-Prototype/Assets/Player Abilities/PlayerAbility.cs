using UnityEngine;
abstract public class PlayerAbility : MonoBehaviour {
	public string abilityName;

	public float[] baseCooldowns = new float[3];

	public int[] upgradeCosts = new int[4];
	public int getUpgradeCost() { return upgradeCosts[level]; }

	protected int level;
	public int getLevel() { return level; }

	public abstract void levelUp();
	public abstract void effect ();
}
