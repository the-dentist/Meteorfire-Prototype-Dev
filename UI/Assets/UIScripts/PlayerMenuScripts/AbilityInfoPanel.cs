using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AbilityInfoPanel : MonoBehaviour {
	public Text slotOneDescText;
	public Text slotTwoDescText;
	public Text slotThreeDescText;
	public Text slotFourDescText;

	private string slotOne;
	private string slotTwo;
	private string slotThree;
	private string slotFour;

	// Use this for initialization
	void Start () {
		// Must find ability descriptions from correct script component
		// and place them into string variables, then assign those values
		// to the Text variables

		slotOne = "First Ability";
		slotTwo = "Second Ability";
		slotThree = "Third Ability";
		slotFour = "Fourth Ability";

		updateValues ();
	}
	
	// Update is called once per frame
	void Update () {
		updateValues ();
	}

	void updateValues() {
		slotOneDescText.text = slotOne;
		slotTwoDescText.text = slotTwo;
		slotThreeDescText.text = slotThree;
		slotFourDescText.text = slotFour;
	}
}
