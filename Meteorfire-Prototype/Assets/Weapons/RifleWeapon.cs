using UnityEngine;
using UnityEditor;

public class RifleWeapon : Weapon {
	protected float bulletwidth, knockback, range;

	void DrawLine(Vector2 start, Vector2 end, Color color, float duration = 0.005f) {
		GameObject myLine = new GameObject();

		myLine.transform.position = start;
		myLine.AddComponent<LineRenderer>();

		LineRenderer lr = myLine.GetComponent<LineRenderer>();

		lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
		lr.SetPosition(0, start);
		lr.SetPosition(1, end);
		lr.startColor = (new Color(.5F, .5F, .5F, 0.2F));
		lr.endColor = (new Color(.8F, .8F, .8F, 0.8F));

		GameObject.Destroy(myLine, duration);

		lr.widthMultiplier = 0.01f * bulletwidth;
		lr.sortingOrder = 2;
	}

	public override void shoot () {
		Vector2 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		var recoilPos = mousePos + Random.insideUnitCircle * .15f;
		Vector2 firePointPosition = GameObject.FindWithTag ("guntip").transform.position;

		Ray2D r = new Ray2D(firePointPosition, recoilPos - firePointPosition);
		Vector2 rangedist = r.GetPoint(range);

		RaycastHit2D hit = Physics2D.Raycast (firePointPosition, recoilPos - firePointPosition, range);

		if (hit.collider != null) {
			GameObject hitobject = hit.transform.gameObject;
			float hitdist = Vector2.Distance (firePointPosition, (Vector2)hitobject.transform.position);

			if ((hit) && hitobject.tag == "Enemy")
			{
				Vector2 splatdist = r.GetPoint ((firePointPosition - (Vector2)hitobject.transform.position).magnitude); //use this later to make splat behind enemy in reference to player
				Vector2 hitobjectdist = r.GetPoint (hitdist);
				DrawLine (firePointPosition, hitobjectdist, Color.white, 0.02f);
				Debug.Log ("Player Hit : " + hitobject.transform.name);


				if (hitobject != null && hitobject.GetComponent<Rigidbody2D> () != null && hitobject.tag != "Wall") {
					hitobject.GetComponent<Rigidbody2D> ().position = Vector2.MoveTowards(hitobject.transform.position, player.transform.position, (-knockback/5));
					hitobject.GetComponent<HealthManager>().damage(30.0f, player.GetComponent<Player>());
				}
			}

		} else {
			DrawLine (firePointPosition, rangedist, Color.white, 0.02f);
			Debug.Log ("Player Hit : Noothing ");
		}
	}

	[CustomEditor(typeof(RifleWeapon),true)]
	public class WeaponEditor : Editor {
		public override void OnInspectorGUI() {
			RifleWeapon rifle = target as RifleWeapon;

			rifle.fireDelay= EditorGUILayout.FloatField("FireRate", rifle.fireDelay);
			rifle.range = EditorGUILayout.FloatField("Range", rifle.range);
			rifle.knockback = EditorGUILayout.FloatField("Knockback", rifle.knockback);
			rifle.bulletwidth = EditorGUILayout.FloatField("Bullet Width", rifle.bulletwidth);

			if (GUI.changed) {
				EditorUtility.SetDirty (target);
			}
		}
	}
}

