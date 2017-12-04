using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenuHotkey : MonoBehaviour {
	Button upgradeMenuButton;

	// Use this for initialization
	void Start () {
		upgradeMenuButton = GetComponent<Button> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.U))
			upgradeMenuButton.onClick.Invoke ();
	}
}
