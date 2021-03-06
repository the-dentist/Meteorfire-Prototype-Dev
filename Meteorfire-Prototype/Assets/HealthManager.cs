using UnityEngine;

//TODO where does armor go? in this class or some combo class or somewhere else?
//TODO figure out how armor works

// this class manages the current hitpoints for a unit
public class HealthManager {
	protected float maxhp;
	protected float currenthp;
	protected float armor;

	public void setHP(float value) {
		maxhp = value;
		currenthp = value;
	}

	public void increaseMaxHP(float value) {
		maxhp += value;
		currenthp += value;
	}

	public float getMaxhp() {
		return maxhp;
	}

	public float getCurrenthp() {
		return currenthp;
	}

	public void setArmor(float value) {
		armor = value;
	}

	public void increaseArmor(float value) {
		armor += value;
	}

	public float getArmor() {
		return armor;
	}

	public void damage(float value, Unit source) {
		value  *= (1 - armor * 0.1f);
		currenthp = Mathf.Max (currenthp - value, 0);
	}

	public void heal(float value) {
		currenthp = Mathf.Min (currenthp + value, maxhp);
	}
}
