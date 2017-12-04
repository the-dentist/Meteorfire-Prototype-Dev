using UnityEngine;

public class Spawner : MonoBehaviour {
	[SerializeField]
	protected GameObject spawn = null;
	[SerializeField]
	protected float spawnTime = 1f;

	float lastSpawn = 0;

	void Update () {
		if (spawn != null) {
			float now = Time.time;
			if (now - spawnTime >= lastSpawn) {
				lastSpawn = now;
				Instantiate (spawn);
			}
		}
	}
}
