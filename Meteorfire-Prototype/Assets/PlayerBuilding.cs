using UnityEngine;

public class PlayerBuilding : MonoBehaviour {
	BuildingManager bm;

	public void Awake() {
		bm = GameObject.FindGameObjectWithTag("Player").GetComponent<BuildingManager>();
	}

	public void OnMouseEnter() {
		bm.setMouseOver (this);
	}

	public void OnMouseExit() {
		bm.removeMouseOver (this);
	}
}
