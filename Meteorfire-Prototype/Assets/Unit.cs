using UnityEngine;

public class Unit : MonoBehaviour {
	protected HealthManager hm = new HealthManager();
	protected CharacterController cc;

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
	protected float moveSpeed = 3f;
	[SerializeField]
	protected float basehp = 1f;
	[SerializeField]
	protected float hpPerLevel = 1f;

	[SerializeField]
	protected int level = 1;

	[SerializeField]
	protected GameObject target = null;

	public virtual void Awake() {
		cc = GetComponent<CharacterController> ();
		hm.setHP (basehp + (level-1)*hpPerLevel);
	}

	public virtual void Update() {
		if (isMoveable) {
			if (target != null) {
				move (target.transform.position);
			}
		}
	}
		
	public virtual void move(Vector2 direction) {
		Vector2 movement = direction * moveSpeed;
		cc.Move (movement * Time.deltaTime);
	}

	public void setTarget(GameObject g) {
		target = g;
	}

	public int getLevel() { 
		return level; 
	}

	public float getMaxHP() { 
		return hm.getMaxhp(); 
	}

	public virtual void levelUp() { 
		level += 1; 
		hm.increaseMaxHP (hpPerLevel);
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
