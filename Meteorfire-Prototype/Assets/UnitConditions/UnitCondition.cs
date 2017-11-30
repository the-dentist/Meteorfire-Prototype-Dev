using UnityEngine;

public abstract class UnitCondition : MonoBehaviour{
	public float duration = 1f;
	public float value = 0;

	protected float startTime;
	protected Unit target;

	protected bool enabled = false;

	public float getStartTime() {
		return startTime;
	}

	public void enable() {
		startTime = Time.time;
		target = GetComponent<Unit> ();
		enabled = true;
		onConditionStart ();
	}

	public void OnDisable() {
		onConditionEnd ();
	}

	public void Update() {
		if (enabled) {
			float now = Time.time;
			if (startTime + duration <= now) {
				Destroy (this);
			}
		}
	}		

	public abstract void onConditionStart ();
	public abstract void onConditionEnd ();
}
