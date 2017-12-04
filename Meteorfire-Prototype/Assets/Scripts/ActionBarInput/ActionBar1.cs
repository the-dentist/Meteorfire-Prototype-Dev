using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionBar1 : MonoBehaviour {
	Button ability1;

	// Use this for initialization
	void Start () {
		ability1 = gameObject.GetComponent<Button> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			ability1.onClick.Invoke ();
		}
	}

	public void pressTest() {
		Debug.Log ("Key '1' has been pressed.");
	}

	public void activateAbility() {
		// Use 'Player' GameObject to access playerInfomation,
		// determine what ability is in slot 1 (string ability1 in
		// playerInformation script), then
		// use that value to call corresponding
		// ability script for usage

		// Maybe...

		// currentAbility = GameObject.FindWithTag("Player").ability1Name;

		// then use that string to call activation function with that ability name...

		// GameObject.FindWithTag(currentAbility).activate();
	}
}
