﻿using UnityEngine;

public class BigBoltAbility : PlayerAbility {
	[SerializeField]
	protected int[] damages = new int[] {1,2,3};
	[SerializeField]
	protected GameObject bigBoltObject;

	public override void effect() {
		Vector2 currentLocation = transform.position;
		Vector2 cursorLocation = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Ray2D r = new Ray2D (currentLocation, cursorLocation - currentLocation);
		Vector2 rangedist = r.GetPoint (2);
	
		bigBoltObject.GetComponent<BigBoltObject>().damage = damages [level - 1];
		Instantiate(bigBoltObject, rangedist, Quaternion.LookRotation(Vector3.forward, cursorLocation - currentLocation) );
	}
} 
	