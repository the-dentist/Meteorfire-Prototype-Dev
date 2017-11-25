using UnityEngine;

//TODO where does armor go? in this class or some combo class or somewhere else?
//TODO figure out how armor works

// this class manages the current hitpoints for a unit
public class HealthManager : MonoBehaviour {
	protected float hp;
	protected Unit unit;

	void Start () {
		unit = GetComponent<Unit> ();
		hp = unit.getMaxHP();
	}

	public float getHP() {
		return hp;
	}

	public void damage(float value, Unit source) {
		hp = Mathf.Max (hp - value, 0);
		if (hp == 0) unit.getKilled(source);
	}

	public void heal(float value) {
		hp = Mathf.Min (hp + value, unit.getMaxHP ());
	}
}
