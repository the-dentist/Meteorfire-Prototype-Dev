using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionBar4 : MonoBehaviour {
	Button ability4;

	// Use this for initialization
	void Start () {
		ability4 = gameObject.GetComponent<Button> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKeyDown (KeyCode.Alpha4)) {
			ability4.onClick.Invoke ();
		}
	}

	public void pressTest() {
		Debug.Log ("Key '4' has been pressed.");
	}

	public void activateAbility() {
		// Use 'Player' GameObject to access playerInfomation,
		// determine what ability is in slot 4 (string ability4 in
		// playerInformation script), then
		// use that value to call corresponding
		// ability script for usage

		// Maybe...

		// currentAbility = GameObject.FindWithTag("Player").ability4Name;

		// then use that string to call function with that ability name...

		// GameObject.FindWithTag(currentAbility).activate();
	}
}
