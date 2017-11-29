using UnityEngine;

// manages which gun the player is firing
public class WeaponManager : MonoBehaviour {
	[SerializeField]
	protected int currentWeapon = 0;
	[SerializeField]
	protected float recoilwidth = 0.05f;

	Weapon[] availableWeapons;

	Player player;

	public void Awake () {
		availableWeapons = GetComponents<Weapon> ();
		player = transform.parent.gameObject.GetComponent<Player>();
	}

	public void Update() {
		if (Input.GetButtonDown ("Fire1")) {
			Vector2 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Vector2 targetLocation = mousePos + Random.insideUnitCircle * recoilwidth;
			fire (targetLocation);
		}
	}

	public void toggleWeapon () {
		currentWeapon = (currentWeapon + 1) % availableWeapons.Length;
	}

	public void fire(Vector2 target) {
		availableWeapons [currentWeapon].fire (player, target);
	}
}

