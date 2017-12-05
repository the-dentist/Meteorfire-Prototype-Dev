using UnityEngine;

public class BuildingManager : MonoBehaviour {
	[SerializeField]
	protected GameObject Wall;

	protected GameObject mouseTarget = null;

	public void buildWallAtCursor() {
		var camerapos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		camerapos.z = 0;
	}

	public void buildTurretAtCursor() {

	}

	public void setMouseOver(GameObject g) {
		mouseTarget = g;
	}

	public void removeMouseOver(GameObject g) {
		if (mouseTarget == g)
			mouseTarget = null;
	}
}
	