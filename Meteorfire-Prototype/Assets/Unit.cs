using UnityEngine;
using System.Collections.Generic;

public class Unit : MonoBehaviour {
	protected HealthManager hm = new HealthManager();
	protected CharacterController cc;

	[SerializeField]
	public string unitName;

	[SerializeField]
	protected bool canMove = false;
	[SerializeField]
	protected bool canAttack = false;

	[SerializeField]
	protected bool isVulnerable = false;
	[SerializeField]
	protected bool isFriendly = false;


	[SerializeField]
	protected bool isPickup = false;

	[SerializeField]
	protected float moveSpeed = 3f;
	protected float moveSpeedModifier = 0f;

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
		if (canMove) {
			if (target != null) {
				move (target.transform.position-transform.position);
			}
		}
	}
		
	public virtual void move(Vector2 direction) {
		Vector2 movement = direction * (moveSpeed + moveSpeedModifier);
		cc.Move (movement * Time.deltaTime);
	}

	public void changeSpeed (float value) {
		moveSpeedModifier += value;
	}

	public void setCanMove(bool value) {
		canMove = value;
	}

	public bool getCanMove() {
		return canMove;
	}

	public void setCanAttack(bool value) {
		canAttack = value;
	}

	public bool getCanAttack() {
		return canAttack;
	}

	public void setIsVulnerable(bool value) {
		isVulnerable = value;
	}

	public bool getIsVulnerable() {
		return isVulnerable;
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
		Debug.Log (unitName + " Hit by " + source.unitName); 
		Debug.Log (unitName + " Has " + getCurrentHP ().ToString () + "HP left");
		if (isVulnerable && isFriendly != source.isFriendly) {
			hm.damage (damage, source);
			if (hm.getCurrenthp () == 0) 
				getKilled(source);
		}
	}

	public virtual void getKilled(Unit killer) { 
		die ();
	}

	public virtual void die() {
		Destroy (gameObject); 
	}

	public bool getIsFriendly() {
		return isFriendly;
	}

	public float getCurrentHP() {
		return hm.getCurrenthp ();
	}

	public void setIsFriendly(bool value) {
		isFriendly = value;
	}

	public float getHealthPercent() {
		return hm.getCurrenthp () / hm.getMaxhp ();
	}
}
