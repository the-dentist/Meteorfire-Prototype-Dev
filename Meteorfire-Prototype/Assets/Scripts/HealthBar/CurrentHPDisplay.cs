using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentHPDisplay : MonoBehaviour {
	Text currentHPText;
	Image HPImage;
<<<<<<< HEAD
	float exampleCurrentHP;

	// Use this for initialization
	void Start () {
		exampleCurrentHP = 100f;
		currentHPText = GetComponent<Text> ();
		currentHPText.text = exampleCurrentHP.ToString () + "/";
=======
	float currentHP;

	Player player;

	void Awake () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player> ();
		currentHP = player.getCurrentHP ();
		currentHPText = GetComponent<Text> ();
		currentHPText.text = currentHP.ToString () + "/";
>>>>>>> master
	}

	// Call this function whenever player health
	// is increased or decreased in order to 
	// update Current Health displayed on player
	// healthbar
	public void UpdateCurrentHP() {
<<<<<<< HEAD
		// Likely use a get function on Player gameobject
		// to determine current value of HP (from the health
		// component script)
		HPImage = GameObject.FindWithTag("PlayerHealthBar").GetComponent<Image>();
		exampleCurrentHP = HPImage.fillAmount;
		float updateValue = Mathf.Round ((exampleCurrentHP * 100));
		currentHPText.text = updateValue.ToString () + "/";
=======
		HPImage = GameObject.FindGameObjectWithTag("PlayerHealthBar").GetComponent<Image>();
		currentHP = player.getCurrentHP();
		currentHPText.text = currentHP.ToString() + "/";
>>>>>>> master
	}
}
