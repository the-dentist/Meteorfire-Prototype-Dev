﻿using UnityEngine;
using System.Collections;

public class BigBoltAbility : PlayerAbility {
	public GameObject boltlight;

	IEnumerator killself()
	{
		yield return new WaitForSeconds (0.3f);
		Destroy(gameObject);
	}

	void OnCollisionStay2D(Collision2D col) {
		if (col.gameObject.tag == "Enemy") {
			col.gameObject.GetComponent<HealthManager>().damage(4, player);
			Instantiate (boltlight, col.gameObject.transform.position, Quaternion.identity);
		}
	}

	public override void effect() {
		StartCoroutine (killself ());
		Instantiate (boltlight, transform.position, Quaternion.identity);
	}
} 

