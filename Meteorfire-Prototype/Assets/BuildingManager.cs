using UnityEngine;

public class BuildingManager : MonoBehaviour {
	[SerializeField]
	protected GameObject Wall;

	protected PlayerBuilding mouseTarget = null;

	public void buildWallAtCursor() {
		var camerapos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		camerapos.z = 0;
	}

	public void buildTurretAtCursor() {

	}

	public void setMouseOver(PlayerBuilding pb) {
		mouseTarget = pb;
	}

	public void removeMouseOver(PlayerBuilding pb) {
		if (mouseTarget == pb)
			mouseTarget = null;
	}
}
	