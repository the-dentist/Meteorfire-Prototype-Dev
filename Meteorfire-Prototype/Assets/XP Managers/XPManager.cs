using UnityEngine;

// an XPManager is set up to monitor the experience gains of a type of unit (player or enemy)
abstract public class XPManager : MonoBehaviour {
	protected float current_xp;
	protected float required_xp;

	public virtual void Start () {
		current_xp = 0;
		update_required_xp();
	}

	protected abstract void levelUp ();
	protected abstract void update_required_xp ();
}
