using UnityEngine;

public class SlowCondition : UnitCondition {
	public override void onConditionStart () {
		target.changeSpeed (value * -2);
	}

	public override void onConditionEnd () {
		target.changeSpeed (value);
	}
}

