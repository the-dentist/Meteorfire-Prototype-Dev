using UnityEngine;
using System.Collections;

public class PoisonObject : MonoBehaviour {
	public float damage;
	protected Unit player;

	IEnumerator killself() {
		yield return new WaitForSeconds (7f);
		Destroy(gameObject);
	}

	float delay = 0.5f;
	float last = 0f;

	void OnTriggerStay(Collider col) {
		float now = Time.time;
	
		if (delay + last >= now) {
			if (col.gameObject.tag == "Enemy") {
				col.gameObject.GetComponent<Unit> ().damage (damage, (Unit)player);

				SlowCondition sc = col.gameObject.GetComponent<SlowCondition> ();
				if (sc == null) {
					sc = col.gameObject.AddComponent<SlowCondition> ();
					sc.duration = 1;
					sc.value = 2;
				}
				last = now;
			}
		}
	}

	public void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Unit> ();
		StartCoroutine (killself ());
	}
		
}