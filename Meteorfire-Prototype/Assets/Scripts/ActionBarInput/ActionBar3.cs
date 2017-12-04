using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionBar3 : MonoBehaviour {
	Button ability3;
	//string currentAbility;

	// Use this for initialization
	void Start () {
		ability3 = gameObject.GetComponent<Button> ();
		//currentAbility = "";
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			ability3.onClick.Invoke ();
		}
	}

	public void pressTest() {
		Debug.Log ("Key '3' has been pressed.");
	}

	public void activateAbility() {
		// Use 'Player' GameObject to access playerInfomation script,
		// determine what ability is in slot 3 (string ability3 in
		// playerInformation script), then
		// use that value to call corresponding
		// ability script for usage.

		// Maybe...

		// currentAbility = GameObject.FindWithTag("Player").ability3Name;

		// then use that string to call function with that ability name...

		// GameObject.FindWithTag(currentAbility).activate();
	}
}
