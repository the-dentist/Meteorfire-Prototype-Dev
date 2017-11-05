using UnityEngine;

abstract public class PlayerAbility : MonoBehaviour {
	[SerializeField]
	protected string abilityName;

	[SerializeField]
	protected float[] baseCooldowns;

	[SerializeField]
	protected int[] upgradeCosts;
	public int getUpgradeCost() { return upgradeCosts[level]; }

	protected int level;
	public abstract void levelUp();

	public abstract void effect ();

	public string getName() { return abilityName; }
	public int getLevel() { return level; }
}
