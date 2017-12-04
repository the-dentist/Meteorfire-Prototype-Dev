using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentHPDisplay : MonoBehaviour {
	Text currentHPText;
	Image HPImage;
	float currentHP;

	Player player;

	void Awake () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player> ();
		currentHP = player.getCurrentHP ();
		currentHPText = GetComponent<Text> ();
		currentHPText.text = currentHP.ToString () + "/";
	}

	// Call this function whenever player health
	// is increased or decreased in order to 
	// update Current Health displayed on player
	// healthbar
	public void UpdateCurrentHP() {
		HPImage = GameObject.FindGameObjectWithTag("PlayerHealthBar").GetComponent<Image>();
		currentHP = player.getCurrentHP();
		currentHPText.text = currentHP.ToString() + "/";
	}
}
