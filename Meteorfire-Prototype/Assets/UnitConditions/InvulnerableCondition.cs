using UnityEngine;

public class InvulnerableCondition : UnitCondition {
	bool wasVulnerable;

	public override void onConditionStart () {
		wasVulnerable = target.getIsVulnerable ();

		if (!wasVulnerable)
			target.setIsVulnerable (true);
	}

	public override void onConditionEnd () {
		if (!wasVulnerable)
			target.setIsVulnerable(true);
	}
}