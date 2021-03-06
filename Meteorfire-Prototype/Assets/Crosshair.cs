using UnityEngine;

public class Crosshair : MonoBehaviour {
	protected Vector3 mousepos;

	void Start () {
		Cursor.visible = false;
	}
	
	void Update () {
		mousepos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		mousepos.z = 0;
		transform.position = mousepos;
	}
}
