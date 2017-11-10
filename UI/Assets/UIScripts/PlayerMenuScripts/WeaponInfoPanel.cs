using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WeaponInfoPanel : MonoBehaviour {
	public Text currentWeaponText;
	public Text weaponLevelText;
	public Text weaponDamText;
	public Text nextUpgradeText;

	private string currentWeapon;
	private float weaponLevel;
	private float weaponDamage;
	private float nextUpgrade;

	// Use this for initialization
	void Start () {
		// Access correct scripts to pull needed information
		// and store values as strings in text variables
		// For UI development, values will be 0
		currentWeapon = "Nothin'";
		weaponLevel = 0;
		weaponDamage = 0;
		nextUpgrade = 0;

		updateValues ();
	}

	// Update is called once per frame
	void Update () {
		updateValues ();
	}

	void updateValues() {
		currentWeaponText.text = currentWeapon;
		weaponLevelText.text = weaponLevel.ToString ();
		weaponDamText.text = weaponDamage.ToString ();
		nextUpgradeText.text = nextUpgrade.ToString ();
	}
}
