﻿using UnityEngine;

public class Boss : Enemy {
	protected override void determineTarget() {
		target = player;
	}

	// TODO other differences in the boss unit, 
	// probably in tandem with a prefab
}
	