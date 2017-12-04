using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoToolTip : MonoBehaviour {
	public Text playerLevel, playerGold, playerXP;
	float level, gold, experience, expNextLevel;

	// Use this for initialization
	void Start () {
		playerLevel = GameObject.FindWithTag ("PlayerLevelUI").GetComponent<Text> ();
		playerGold = GameObject.FindWithTag ("PlayerGoldUI").GetComponent<Text> ();
		playerXP = GameObject.FindWithTag ("PlayerXPUI").GetComponent<Text> ();

		// Set inital text for display
		level = 1.0f;
		gold = 35.0f;
		experience = 0.0f;
		expNextLevel = 100.0f;

		UpdateDisplay ();
		playerLevel.text = level.ToString ();
		playerGold.text = gold.ToString ();
		playerXP.text = experience.ToString () + "/" + expNextLevel.ToString ();
	}

	public void IncreaseLevel() {
		level++;
		UpdateDisplay ();
	}

	public void IncreaseGold(float addGold) {
		gold += addGold;
		UpdateDisplay ();
	}

	public void DecreaseGold(float delGold) {
		gold -= delGold;
		UpdateDisplay ();
	}

	public void IncreaseExp(float exp) {
		if ((experience += exp) > expNextLevel) {
			experience = (experience += exp) - expNextLevel;

			// Make call to Player gamebject's experience info
			// to set new value of expNextLevel for display

			UpdateDisplay ();
			return;
		}

		if ((experience += exp) == expNextLevel) {
			experience = 0;

			// Make call to Player gamebject's experience info
			// to set new value of expNextLevel for display

			UpdateDisplay ();
			return;
		}

		experience += exp;

		UpdateDisplay ();
	}

	private void UpdateDisplay() {
		playerLevel.text = level.ToString ();
		playerGold.text = gold.ToString ();
		playerXP.text = experience.ToString () + "/" + expNextLevel.ToString ();
	}
}
