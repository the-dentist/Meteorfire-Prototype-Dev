using UnityEngine;

// The default "weapon" is a rifle/rifle clone
public class Weapon : MonoBehaviour {
	[SerializeField]
	protected float fireDelay = 0;
	[SerializeField]
	protected float bulletwidth = 2f;
	[SerializeField]
	protected float range = 20f;
	[SerializeField]
	protected float projectileLingerDuration = 0.2f;
	[SerializeField]
	protected float[] damages = {1};

	[SerializeField]
	protected int level = 1;

	[SerializeField]
	protected Color projectileColor = Color.red;

	float lastFire;

	public virtual void fire(Unit shooter, Vector3 target) {
		float now = Time.time;
		if (now - fireDelay >= lastFire) {
			lastFire = now;
		
			Ray2D firePath = new Ray2D (transform.position, target-transform.position);
			target = firePath.GetPoint (range);

			int layerMask;
			int exclude;
			if (shooter.getIsFriendly ()) {
				exclude = 9;
			} else {
				exclude = 10;
			}

			// Bit shift the index of the layer to get a bit mask
			layerMask = 1 << exclude;
			// we want to collide against everything except exclude. The ~ operator does this.
			layerMask = ~layerMask;

			RaycastHit info;
			if(Physics.Raycast (transform.position, target-transform.position, out info, range, layerMask)) {
				GameObject victim = info.transform.gameObject;
				DrawLine (transform.position, info.point, projectileColor);
				victim.GetComponent<Unit> ().damage (damages[level-1], shooter);
			} else {
				DrawLine (transform.position, target, projectileColor);
			}
		}
	}

	void DrawLine(Vector2 start, Vector2 end, Color color) {
		GameObject line = new GameObject();

		line.transform.position = start;
		line.AddComponent<LineRenderer>();

		LineRenderer lr = line.GetComponent<LineRenderer>();
		lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
		lr.SetPosition(0, start);
		lr.SetPosition(1, end);
		lr.startColor = (projectileColor);
		lr.endColor = (new Color(.8F, .8F, .8F, 0.8F));
		lr.widthMultiplier = 0.01f * bulletwidth;
		lr.sortingOrder = 2;

		GameObject.Destroy(line, projectileLingerDuration);
	}

	public float getRange() {
		return range;
	}
}