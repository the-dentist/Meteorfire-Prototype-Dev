using UnityEngine;
using System.Collections;

public class PoisonObject : MonoBehaviour {
	public int damage;
	protected Unit player;

	IEnumerator killself() {
		yield return new WaitForSeconds (10f);
		Destroy(gameObject);
	}

	void OnCollisionStay2D(Collision2D col) {
		if (col.gameObject.tag == "Enemy") {
			col.gameObject.GetComponent<Unit>().damage(damage, (Unit)player);
		}
	}

	public void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Unit> ();
		StartCoroutine (killself ());
	}
}

