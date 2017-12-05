using UnityEngine;

public class StunCondition : UnitCondition {
	bool couldMove;
	bool couldAttack;

	public override void onConditionStart () {
		couldMove = target.getCanMove ();
		couldAttack = target.getCanAttack ();

		if (couldMove)
			target.setCanMove(false);
		if (couldAttack)
			target.setCanAttack (false);
	}

	public override void onConditionEnd () {
		if (couldMove)
			target.setCanMove(true);
		if (couldAttack)
			target.setCanAttack (true);
	}
}