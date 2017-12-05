using UnityEngine;

public class BlinkAbility : PlayerAbility {
	[SerializeField]
<<<<<<< HEAD
	protected float[] ranges = new float[] {3,6,9};
=======
	protected float[] ranges = new float[] {10,20,30};
>>>>>>> master

	public override void effect() {
		Vector2 currentLocation = transform.position;
		Vector2 cursorLocation = Camera.main.ScreenToWorldPoint (Input.mousePosition);

		Ray2D r = new Ray2D (currentLocation, cursorLocation - currentLocation);
		Vector2 target = r.GetPoint (ranges[level-1]);
		transform.parent.transform.position = target;
	}
}
