using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthDisplay : MonoBehaviour {
	Image healthBar;
	float testDam, testHeal;

	// Use this for initialization
	void Start () {
		healthBar = gameObject.GetComponent<Image> ();
		// Test values to determine proper operation of healthbar
		testDam = 23f;
		testHeal = 17f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		// Test damage
		if (Input.GetKeyDown (KeyCode.X)) {
			TestDamage (testDam/100);
		}
		// Test healing
		if (Input.GetKeyDown (KeyCode.C)) {
			TestHealing (testHeal/100);
		}
	}

	// call this function when damaged is inflicted,
	// passed value is percentage of total health
	// to be removed
	public void TestDamage(float damage) {
	    healthBar.fillAmount -= damage;
		GameObject.FindWithTag ("CurrentHPDisplay").GetComponent<CurrentHPDisplay> ().UpdateCurrentHP ();
	}

	// call this function when health is restored,
	// passed value is percentage of total health
	// to be restored
	public void TestHealing(float heal) {
		healthBar.fillAmount += heal;
		GameObject.FindWithTag ("CurrentHPDisplay").GetComponent<CurrentHPDisplay> ().UpdateCurrentHP ();
	}
}
