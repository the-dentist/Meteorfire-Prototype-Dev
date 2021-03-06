﻿using UnityEngine;

public class MiasmaAbility : PlayerAbility {
	[SerializeField]
	protected int[] damages = new int[] {1,2,3};
	[SerializeField]
	protected GameObject PoisonObject;

	public override void effect() {
		Vector2 currentLocation = transform.position;
		Vector2 cursorLocation = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Ray2D r = new Ray2D (currentLocation, cursorLocation - currentLocation);
		Vector2 rangedist = r.GetPoint (3);

		PoisonObject.GetComponent<PoisonObject>().damage = damages [level - 1];

		Instantiate(PoisonObject, cursorLocation, Quaternion.LookRotation(Vector3.forward, cursorLocation - currentLocation) );
	}
} 
