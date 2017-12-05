using UnityEngine;

public class Boss : Enemy {
	[SerializeField]
	protected GameObject spawn = null;


	[SerializeField]
	protected float spawnTime = 3f;

	float lastSpawn = 0;

	void FixedUpdate () {
		//Instantiate(spawn, gameObject.transform.position, Quaternion.identity);

	
			float now = Time.time;
			if (now - spawnTime >= lastSpawn) {
				lastSpawn = now;
				for(int i=0; i<3; i++){
				Instantiate(spawn, gameObject.transform.position, Quaternion.identity);
				}
			}
	}

	protected override void determineTarget() {
		target = player;
	}

	// TODO other differences in the boss unit, 
	// probably in tandem with a prefab
}
	