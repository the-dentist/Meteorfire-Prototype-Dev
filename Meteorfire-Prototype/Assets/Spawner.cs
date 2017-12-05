using UnityEngine;

public class Spawner : MonoBehaviour {
	[SerializeField]
	protected GameObject spawn = null;
	[SerializeField]
	protected GameObject boss = null;
	[SerializeField]
	protected float spawnTime = 1f;
	[SerializeField]
	protected float bossspawnTime = 10f;

	float lastSpawn = 0;
	float lastbossSpawn = 0;

	void Update () {
		float now = Time.time;
		if (spawn != null) {
			if (now - spawnTime >= lastSpawn) {
				lastSpawn = now;
				Instantiate (spawn, transform.position, transform.rotation);
			}
		}
		if (now - bossspawnTime >= lastbossSpawn) {
			lastbossSpawn = now;
			spawnboss ();
		}
	}

	void spawnboss(){
		GameObject[] getCount = GameObject.FindGameObjectsWithTag ("Boss");
		int count = getCount.Length;
		if (count < 1) Instantiate (boss, transform.position, transform.rotation);
	}
}
