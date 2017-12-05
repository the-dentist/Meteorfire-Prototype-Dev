using UnityEngine;

public class BuildingManager : MonoBehaviour {
	[SerializeField]
	protected GameObject Wall;

	public void buildWallAtCursor() {
		var camerapos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		camerapos.z = 0;
	}

	public void buildTurretAtCursor() {

	}
}
	