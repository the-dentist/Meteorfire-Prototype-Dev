using UnityEngine;
abstract public class PlayerAbility : MonoBehaviour {
	[SerializeField]
	public string abilityName;

	[SerializeField]
	protected int level;

	[SerializeField]
	protected float[] baseCooldowns = new float[3];

	[SerializeField]
	public int[] upgradeCosts = new int[4];

	public const int maxLevel = 3;

	protected Player player;

	public void Awake() {
		player = transform.parent.gameObject.GetComponent<Player> ();
	}

	public int getUpgradeCost() { return upgradeCosts[level]; }
	public float getCooldown() { return baseCooldowns [level - 1]; }
	public int getLevel() { return level; }

	public void levelUp() { level = Mathf.Max (level + 1, maxLevel);}

	public abstract void effect ();
}
