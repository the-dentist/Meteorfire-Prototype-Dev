using UnityEngine;
using System.Collections;

public class BigBoltObject : MonoBehaviour {
	public float damage;
	protected Unit player;

	IEnumerator killself() {
		yield return new WaitForSeconds (0.3f);
		Destroy(gameObject);
	}

	void OnTriggerStay(Collider col) {
		if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "Boss"  ) {
			col.gameObject.GetComponent<Unit>().damage(damage, (Unit)player);
		}
	}

	public void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Unit> ();
		StartCoroutine (killself ());
	}

}

