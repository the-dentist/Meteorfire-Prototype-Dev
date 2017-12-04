using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseUpgradesHotkey : MonoBehaviour {

	Button closeMenu;

	// Use this for initialization
	void Start () {
		closeMenu = GetComponent<Button> ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.U))
			closeMenu.onClick.Invoke ();
	}
}
