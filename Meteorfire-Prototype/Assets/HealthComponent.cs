using UnityEngine;

// this class manages the current hitpoints for a unit
public class HealthComponent : MonoBehaviour {
	protected float currenthealth;
	protected Unit context;

	void Start () {
		context = gameObject.GetComponent<Unit> ();
		currenthealth = context.getMaxhp();
	}

	public void damage(int value, Unit source) {
		currenthealth = Mathf.Max (currenthealth - value, 0);
		if (currenthealth == 0) {
			EventManager.SignalKill (source, context); 
			Destroy (gameObject);
		}
	}

	public void Heal(int value, Unit source) {
		currenthealth = Mathf.Min (currenthealth + value, context.getMaxhp ());
	}
}
