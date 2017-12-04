using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityPanel1 : MonoBehaviour {
	public Text abilityName;
	public Image abilityImage;
	public Button upgradeButton;
	public Text currentRankText;

	// Use this for initialization
	void Start () {
		abilityName = GameObject.FindWithTag ("UpgradesAbility1Name").GetComponent<Text> ();
		abilityImage = GameObject.FindWithTag ("UpgradesAbility1Image").GetComponent<Image> ();
		upgradeButton = GameObject.FindWithTag ("UpgradesAbility1Button").GetComponent<Button> ();
		currentRankText = GameObject.FindWithTag ("UpgradesAbility1RankValue").GetComponent<Text> ();

		//abilityImage.sprite = GameObject.FindWithTag ("Player").GetComponent<AbilityManager> ().GetImage (abilityName.text);
		//currentRankText = GameObject.FindWithTag("Player").GetComponent<AbilityManager>().GetCurrentRank(abilityName.text);
	}
}
