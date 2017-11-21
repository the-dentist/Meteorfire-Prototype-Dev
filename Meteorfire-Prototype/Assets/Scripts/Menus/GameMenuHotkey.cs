using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenuHotkey : MonoBehaviour {
	Button gameMenuButton;

	// Use this for initialization
	void Start () {
		gameMenuButton = GetComponent<Button> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
				gameMenuButton.onClick.Invoke ();
		}
	}
}
