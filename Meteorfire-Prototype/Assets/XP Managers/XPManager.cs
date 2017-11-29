using UnityEngine;

// an XPManager is set up to monitor the experience gains of a type of unit (player or enemy)
abstract public class XPManager : MonoBehaviour {
	[SerializeField]
	protected float currentXP = 0;

	protected float requiredXP;

	public virtual void Update() {
		updateRequiredXP();
	}

	protected abstract void levelUp ();
	protected abstract void updateRequiredXP ();
	public abstract void gainXP (Unit source, Unit victim);
}
