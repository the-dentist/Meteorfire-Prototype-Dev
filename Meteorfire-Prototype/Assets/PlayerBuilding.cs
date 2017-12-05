using UnityEngine;

public class PlayerBuilding : MonoBehaviour {
	BuildingManager bm;

	public void Awake() {
		bm = GameObject.FindGameObjectWithTag("Player").GetComponent<BuildingManager>();
	}


}
