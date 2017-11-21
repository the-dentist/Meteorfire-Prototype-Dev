using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaxHPDisplay : MonoBehaviour {
	Text maxHPText;
	float exampleMaxHP;

	// Use this for initialization
	void Start () {
		exampleMaxHP = 100f;
		maxHPText = GetComponent<Text> ();
		maxHPText.text = exampleMaxHP.ToString ();
	}

	// Call this function upon level up
	// to increase MaxHP value displayed on player healthbar
	public void UpdateMaxHP(float percentIncrease) {
		exampleMaxHP += (exampleMaxHP * percentIncrease);
	}
}
