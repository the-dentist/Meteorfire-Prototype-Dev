using UnityEngine;

public class BlinkAbility : PlayerAbility {
	[SerializeField]
	protected float[] ranges = new float[3];

	public override void effect() {
		Vector2 currentLocation = transform.position;
		Vector2 cursorLocation = Camera.main.ScreenToWorldPoint (Input.mousePosition);

		Ray2D r = new Ray2D (currentLocation, cursorLocation - currentLocation);
		Vector2 target = r.GetPoint (ranges[level-1]);
		transform.parent.transform.position = target;
	}
}
