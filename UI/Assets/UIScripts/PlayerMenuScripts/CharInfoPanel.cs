using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CharInfoPanel : MonoBehaviour {
	public Text currentLevel;
	public Text maxHP;

	private float level;
	private float maxHealth;

	// Use this for initialization
	void Start () {
		// Access correct scripts to pull needed information
		// and store values as strings in text variables
		// For UI development, values will be 0
		level = 0;
		maxHealth = 0;

		updateValues ();
	}
	
	// Update is called once per frame
	void Update () {
		updateValues ();
	}

	void updateValues() {
		currentLevel.text = level.ToString ();
		maxHP.text = maxHealth.ToString ();
	}
}
