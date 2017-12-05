using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaxHPDisplay : MonoBehaviour {
	Text maxHPText;
<<<<<<< HEAD
	float exampleMaxHP;

	// Use this for initialization
	void Start () {
		exampleMaxHP = 100f;
		maxHPText = GetComponent<Text> ();
		maxHPText.text = exampleMaxHP.ToString ();
=======
	float maxHP;
	Player player;

	void Awake() {
		player = GameObject.FindWithTag ("Player").GetComponent<Player> ();
	}

	void Update() {
		maxHP = player.getMaxHP ();
		maxHPText = GetComponent<Text> ();
		maxHPText.text = maxHP.ToString ();
>>>>>>> master
	}

	// Call this function upon level up
	// to increase MaxHP value displayed on player healthbar
	public void UpdateMaxHP(float percentIncrease) {
<<<<<<< HEAD
		exampleMaxHP += (exampleMaxHP * percentIncrease);
=======
		maxHP += (maxHP * percentIncrease);
>>>>>>> master
	}
}
