using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerInfoPanel : MonoBehaviour {
	// Text variables to be displayed in UI
	public Text playerLevel;
	public Text playerHealth;
	public Text playerGold;

	// Float values to be converted into strings
	private float level;
	private float health;
	private float gold;

	// Use this for initialization
	void Start () {
		// First must access correct components from other scripts
		// in order to initialize float values, then place those 
		// values into corresponding text variables with updateValue()
		// function call
		// All three values are initialized to 0 for testing UI
		level = 0;
		health = 0;
		gold = 0;

		updateValues ();
	}
	
	// Update is called once per frame
	void Update () {
		updateValues ();
	}

	void updateValues() {
		playerLevel.text = level.ToString ();
		playerHealth.text = health.ToString ();
		playerGold.text = gold.ToString ();
	}
}
