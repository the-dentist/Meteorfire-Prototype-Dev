using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthDisplay : MonoBehaviour {
	Image healthBar;
	Player player;
	CurrentHPDisplay chp;

	void Awake () {
		healthBar = GetComponent<Image> ();
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player>();
		chp = GameObject.FindWithTag ("CurrentHPDisplay").GetComponent<CurrentHPDisplay> ();
	}

	public void Update() {
		chp.UpdateCurrentHP ();
	}

	// call this function when damaged is inflicted,
	// passed value is percentage of total health
	// to be removed
	public void Damage(float damage) {
		healthBar.fillAmount = player.getHealthPercent();
	}

	// call this function when health is restored,
	// passed value is percentage of total health
	// to be restored
	public void Healing(float heal) {
		healthBar.fillAmount = player.getHealthPercent ();
	}
}
