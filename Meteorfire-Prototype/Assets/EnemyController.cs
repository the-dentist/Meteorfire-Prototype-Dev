using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class determines the combat abilities of the enemies 
// The enemies "level up" similarly to how the player does
public class EnemyController : MonoBehaviour {
	// The "level" of the enemy controller is similar to a wave number
	// the higher it is the harder the waves get
	protected int level;

	public void start() {
		level = 1;
	}

	public void levelUp() {
		level += 1;
	}

	public int getLevel() { return level; }

	// TODO some kind of template for enemy level 1/2/3 or some algorithm to determine their stats
}
