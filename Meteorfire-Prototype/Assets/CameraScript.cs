using UnityEngine;

public class CameraScript : MonoBehaviour {
	public GameObject wall;
	public bool canbuild;

	protected GameObject wallclone, player, weapon;
	protected Vector3 offset;

	void Awake() {
		player = GameObject.FindWithTag("Player");
		offset = gameObject.transform.position - player.transform.position;
	}

	void Update () {
		gameObject.transform.position = player.transform.position + offset;

		var camerapos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		camerapos.z = 0;
	}
}