using UnityEngine;

// manages which gun the player is firing
public class WeaponManager : MonoBehaviour {
	protected int currentWeapon;
	public Weapon[] availableWeapons;

	void Start () {
		currentWeapon = 0;
		availableWeapons = GetComponents<Weapon> ();
	}

	public void toggleWeapon () {
		currentWeapon = (currentWeapon + 1) % availableWeapons.Length;
	}

	public void fire() {
		availableWeapons [currentWeapon].fire ();
	}
}

