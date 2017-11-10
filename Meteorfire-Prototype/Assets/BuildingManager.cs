using UnityEngine;

public class BuildingManager : MonoBehaviour {
	public GameObject Wall;

	GameObject Wallclone;

	void Build() {
		var camerapos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		camerapos.z = 0;
	}

}

