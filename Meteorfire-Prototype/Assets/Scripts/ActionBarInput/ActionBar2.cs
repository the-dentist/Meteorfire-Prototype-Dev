using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionBar2 : MonoBehaviour {
	Button ability2;

	// Use this for initialization
	void Start () {
		ability2 = gameObject.GetComponent<Button> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			ability2.onClick.Invoke ();
		}
	}

	public void pressTest() {
		Debug.Log ("Key '2' has been pressed.");
	}

	public void activateAbility() {
		// Use 'Player' GameObject to access playerInfomation,
		// determine what ability is in slot 2 (string ability2 in
		// playerInformation script), then
		// use that value to call corresponding
		// ability script for usage

		// Maybe...

		// currentAbility = GameObject.FindWithTag("Player").ability2Name;

		// then use that string to call function with that ability name...

		// GameObject.FindWithTag(currentAbility).activate();
	}
}
