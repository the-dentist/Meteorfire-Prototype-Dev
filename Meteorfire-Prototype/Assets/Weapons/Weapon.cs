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
	protected float recoilwidth = 0.05f;
	[SerializeField]
	protected float projectileLingerDuration = 0.2f;
	[SerializeField]
	protected float[] damages = {1};

	[SerializeField]
	protected int level = 1;

	[SerializeField]
	protected Color projectileColor = Color.red;

	float lastFire;

	public virtual void fire(Unit shooter, Vector2 target) {
		float now = Time.time;
		if (now - fireDelay >= lastFire) {
			lastFire = now;
		
			RaycastHit2D bullet = Physics2D.Raycast (transform.position, target, range);

			if (bullet.collider != null) {
				GameObject victim = bullet.transform.gameObject;
				DrawLine (transform.position, bullet.point, projectileColor);
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
}