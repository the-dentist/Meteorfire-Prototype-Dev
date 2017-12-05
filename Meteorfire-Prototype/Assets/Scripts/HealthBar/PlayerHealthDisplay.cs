using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthDisplay : MonoBehaviour {
	Image healthBar;
<<<<<<< HEAD
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
=======
	Player player;
	CurrentHPDisplay chp;

	void Awake () {
		healthBar = GetComponent<Image> ();
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player>();
		chp = GameObject.FindWithTag ("CurrentHPDisplay").GetComponent<CurrentHPDisplay> ();
	}

	public void Update() {
		chp.UpdateCurrentHP ();
>>>>>>> master
	}

	// call this function when damaged is inflicted,
	// passed value is percentage of total health
	// to be removed
<<<<<<< HEAD
	public void TestDamage(float damage) {
	    healthBar.fillAmount -= damage;
		GameObject.FindWithTag ("CurrentHPDisplay").GetComponent<CurrentHPDisplay> ().UpdateCurrentHP ();
=======
	public void Damage(float damage) {
		healthBar.fillAmount = player.getHealthPercent();
>>>>>>> master
	}

	// call this function when health is restored,
	// passed value is percentage of total health
	// to be restored
<<<<<<< HEAD
	public void TestHealing(float heal) {
		healthBar.fillAmount += heal;
		GameObject.FindWithTag ("CurrentHPDisplay").GetComponent<CurrentHPDisplay> ().UpdateCurrentHP ();
=======
	public void Healing(float heal) {
		healthBar.fillAmount = player.getHealthPercent ();
>>>>>>> master
	}
}
