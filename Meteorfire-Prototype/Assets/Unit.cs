using UnityEngine;

public class Unit : MonoBehaviour {
	protected HealthManager hm = new HealthManager();

	[SerializeField]
	public string unitName;

	[SerializeField]
	protected bool isMoveable = false;
	[SerializeField]
	protected bool isVulnerable = false;
	[SerializeField]
	protected bool isFriendly = false;
	[SerializeField]
	protected bool isPickup = false;

	[SerializeField]
	protected float moveSpeed = 5f;

	[SerializeField]
	protected int level = 1;

	[SerializeField]
	protected float basehp = 1f;
	[SerializeField]
	protected float hpPerLevel = 1f;

	[SerializeField]
	protected float baseArmor = 0f;
	[SerializeField]
	protected float armorPerLevel = 0f;

	public int getLevel() { 
		return level; 
	}

	public float getMaxHP() { 
		return hm.getMaxhp(); 
	}

	public virtual void Awake() {
		hm.setHP (basehp + (level-1)*hpPerLevel);
		hm.setArmor (baseArmor + (level-1)*armorPerLevel);
	}

	public virtual void levelUp() { 
		level += 1; 
		hm.increaseMaxHP (hpPerLevel);
		hm.increaseArmor (armorPerLevel);
	}

	public virtual void damage (float damage, Unit source) {
		hm.damage (damage, source);
		if (hm.getCurrenthp () == 0) 
			getKilled(source);
	}

	public virtual void getKilled(Unit killer) { 
		die ();
	}

	public virtual void die() {
		Destroy (gameObject); 
	}
}
