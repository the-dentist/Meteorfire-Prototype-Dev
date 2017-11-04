using UnityEngine;

// This class determines the combat abilities of the enemies 
public class EnemyController {
	protected int difficulty;

	public void start() {
		difficulty = 1;
	}

	public void levelUp() {
		difficulty += 1;
	}

	public int getDifficulty() { return difficulty; }

	// TODO build an algorithm to spawn zombies of various
	// levels based on the difficulty
}
