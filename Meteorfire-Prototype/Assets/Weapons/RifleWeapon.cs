using UnityEngine;
using UnityEditor;

public class RifleWeapon : Weapon {
	[SerializeField]
	protected float bulletwidth = 1f;
	[SerializeField]
	protected float knockback = 10f;
	[SerializeField]
	protected float range = .5f;
	[SerializeField]
	protected float recoilwidth = 0.05f;
	[SerializeField]
	protected float projectileLingerDuration = 0.2f;

	[SerializeField]
	protected Color projectileColor = (new Color(.5F, .5F, .5F, 0.2F));

	void DrawLine(Vector2 start, Vector2 end, Color color) {
		GameObject line = new GameObject();

		line.transform.position = start;
		line.AddComponent<LineRenderer>();

		// TODO could this just be a prefab?
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
		
	public override void shoot () {
		/*
		 * 1. determine ray max length and direction
		 * 2. fire the ray and see if it collides with something
		 * 3. if it collides trigger an even in that object
		 */

		// determine where gun will fire
		Vector2 gunLocation = transform.position;
		Vector2 crosshairLocation = Camera.main.ScreenToWorldPoint (Input.mousePosition);

		// add recoil
		Vector2 targetLocation = crosshairLocation + Random.insideUnitCircle * recoilwidth;

		// ensure firing within max range
		Ray2D firePath = new Ray2D (gunLocation, targetLocation-gunLocation);
		targetLocation = firePath.GetPoint (range);

		// Fire bullet
		RaycastHit2D bullet = Physics2D.Raycast (gunLocation, targetLocation, range);

		// if you hit something draw the line only to the object
		if (bullet.collider != null) {
			GameObject victim = bullet.transform.gameObject;

			if (victim.tag == "Wall" || victim.tag == "Enemy") {
				DrawLine (gunLocation, bullet.point, projectileColor);
				Debug.Log ("Player Hit : " + victim.transform.name);

				// if you hit an anemy it gets pushed back
				if (victim.tag == "Enemy") {
					victim.GetComponent<Rigidbody2D> ().position = Vector2.MoveTowards (victim.transform.position, player.transform.position, (-knockback / 5));
					victim.GetComponent<Unit> ().damage (30, player.GetComponent<Player> ());
				}
			}
		} else {
			DrawLine (gunLocation, targetLocation, projectileColor);
			Debug.Log ("Player Hit : Nothing ");
		}
	}

}

