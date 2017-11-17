﻿using UnityEngine;

// This class determines the combat abilities of the enemies 
// also determines the gold and xp rewards
public class EnemyController : MonoBehaviour {
	protected EnemyXPManager exm;
	protected Player player;

	[SerializeField]
	protected int difficulty;

	public void Awake() {
		exm = GetComponent<EnemyXPManager> ();
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
	}

	public void levelUp() {
		difficulty += 1;
	}

	public int getDifficulty() { return difficulty; }

	public int determineGoldValue(Unit victim) {
		if (victim.tag == "Enemy")
			return victim.getLevel() * 10;
		return 0;
	}

	public int determineXPValue(Unit victim) {
		if (victim.tag == "Enemy")
			return victim.getLevel();
		return 0;
	}

	public void logKill(Unit killer, Unit victim) {
		float xp = determineXPValue (victim);
		exm.gainXP (xp);
		player.awardKill(killer, xp, determineGoldValue(victim));
	}

	// TODO build an algorithm to spawn zombies of various
	// levels based on the difficulty
	// TODO make enemy prefabs for level 1/2/3 
	// unless procedural generation is better somehow
}

