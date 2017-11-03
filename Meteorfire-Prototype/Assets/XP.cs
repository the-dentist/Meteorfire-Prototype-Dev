using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// the XP class is attached to a gameobject (player, enemycontroller, etc) 
// it determines how much xp is granted for a kill
// it also tracks xp progress and updates the attached object's level
// this is a purely virtual class that must be modified for particular use
public class XP : MonoBehaviour {
	protected int current_xp;
	protected int required_xp;
	protected Unit context;

	virtual protected int determineXPGain() {}
	virtual protected int determineRequiredXP() {}
}

// This class is intended to be attached to the player object
public class PlayerXP : XP {
	private override int determineXPGain() {
		return 1;
	}

	private override int determineRequiredXP() {
		return context.getLevel();
	}

	public void start() {
		context = Unit(gameObject);
		current_xp = 0;
		required_xp = determineRequiredXP ();
	}
}

// this class is intended to be attached to the enemy controller object
public class EnemyXP : XP {
	private override int determineXPGain() {
		return 1;
	}

	private override int determineRequiredXP() {
		return 10;
	}

	public void start() {
		context = Unit(gameObject);
		current_xp = 0;
		required_xp = determineRequiredXP ();
	}
}

//TODO make enemy death events with unit as parameter
// eg, an event that says [THIS] enemy was killed by [this unit]
// all XP classes losten for that event???
// balance XP gains at all