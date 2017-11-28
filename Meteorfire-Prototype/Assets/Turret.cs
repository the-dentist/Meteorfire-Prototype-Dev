using UnityEngine;
using System.Linq;

public class Turret : Unit {
	[SerializeField]
	protected float[] damages = {1,2,3};

	[SerializeField]
	protected float fireDelay = 0;
	[SerializeField]
	protected float maxRange = 4f;
	[SerializeField]
	protected float knockback = 10f;
	[SerializeField]
	protected float projectileLingerDuration = 0.2f;
	[SerializeField]
	protected float bulletwidth = 2f;

	float lastFire;

	[SerializeField]
	protected Color projectileColor = Color.yellow;

	GameObject target = null;

	public void Update () {
		targetClosestEnemy ();
		if (target != null)
			fire ();
	}

	void targetClosestEnemy() {
		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy").Concat(GameObject.FindGameObjectsWithTag("Boss")).ToArray();

		float minDist = 0;
		GameObject closest = null;

		// only target enemy if in range
		foreach (GameObject enemy in enemies) {
			float dist = Vector2.Distance (transform.position, enemy.transform.position);
			if (dist <= maxRange && (closest == null || dist < minDist)) {
				closest = enemy;
				minDist = dist;
			}
		}

		target = closest;
	}
		
	public void fire() {
		float now = Time.time;
		if (now - fireDelay >= lastFire) {
			lastFire = now;
			shoot ();
		}
	}

	public void shoot () {
		// Draw firepath from turret to target
		Vector2 targetLocation = target.transform.position;
		DrawLine (transform.position, targetLocation, projectileColor);

//		target.GetComponent<Rigidbody2D> ().position = Vector2.MoveTowards (target.transform.position, transform.position, (-knockback / 5));
		target.GetComponent<Unit> ().damage (30, this);
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

}

