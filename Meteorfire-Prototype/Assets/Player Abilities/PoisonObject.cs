using UnityEngine;
using System.Collections;

public class PoisonObject : MonoBehaviour {
	public float damage;
	protected Unit player;

	IEnumerator killself() {
		yield return new WaitForSeconds (7f);
		Destroy(gameObject);
	}

	void OnTriggerStay(Collider col) {
		if (col.gameObject.tag == "Enemy") {
			col.gameObject.GetComponent<Unit>().damage(damage, (Unit)player);
			col.gameObject.AddComponent <SlowCondition>();

		}
	}

	public void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Unit> ();
		StartCoroutine (killself ());
	}
		
}