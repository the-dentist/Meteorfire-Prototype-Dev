using UnityEngine;

public abstract class Unit : MonoBehaviour {
	protected HealthManager hm;

	[SerializeField]
	protected string unitName;

	[SerializeField]
	protected bool isMoveable, isVulnerable, isFriendly, isPickup;

	[SerializeField]
	protected int armor, level, maxhp;

	public string getName() { return unitName; }
	public int getLevel() { return level; }
	public int getMaxHP() { return maxhp; }

	public virtual void levelUp() { level += 1; }

	public void Awake() {
		hm = GetComponent<HealthManager> ();
	}

	public virtual void damage (int damage, Unit source) {
		hm.damage (damage, source);
	}

	public virtual void getKilled(Unit killer) { 
		die ();
	}

	public virtual void die() {
		Destroy (gameObject); 
	}
}
