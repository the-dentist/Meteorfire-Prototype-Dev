using UnityEngine;

public class MovementManager : MonoBehaviour {
	protected Rigidbody2D rb;

	[SerializeField]
	protected int acceleration, maxspeed;

	public void Awake() {
		rb = GetComponent<Rigidbody2D> ();
	}

	public void move(Vector2 direction) {
		rb.AddForce (direction * acceleration);

		// disallow speed greater than max speed
		if (rb.velocity.magnitude > maxspeed) {
			rb.velocity = rb.velocity.normalized * maxspeed;
		}
	}
}
