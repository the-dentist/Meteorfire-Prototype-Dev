using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	public float bulletwidth, knockback, range;
	private GameObject player;
	public float fireRate = 1.0f;
	private float nextFire = 0.0f;
	protected Vector2 tipoffset = new Vector2(.1f,.1f);
	public bool canshoot,canbuild;
	public GameObject Wall;
	GameObject Wallclone;


	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
		knockback = 1;
		canshoot = true;

	}

	void Build() 
	{
		var camerapos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		camerapos.z = 0;

		if (Input.GetKeyDown(KeyCode.B))
		{
			canshoot = !canshoot;
			canbuild = !canbuild;
		}

		if (Input.GetMouseButtonDown (0) && canbuild)

			Instantiate (Wall, camerapos, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position = player.transform.position; //weapon position = player position

		Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position); 
		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Shoot ();
		}
		Build ();
	
	}

	void DrawLine(Vector2 start, Vector2 end, Color color, float duration = 0.2f)
	{
		GameObject myLine = new GameObject();
		myLine.transform.position = start;
		myLine.AddComponent<LineRenderer>();
		LineRenderer lr = myLine.GetComponent<LineRenderer>();
		lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
		lr.SetPosition(0, start);
		lr.SetPosition(1, end);
		GameObject.Destroy(myLine, duration);
		lr.widthMultiplier = 0.01f * bulletwidth;
		lr.sortingOrder = 2;
	}

	void Shoot ()
	{
		//Vector2 mousePos = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition.y));
		Vector2 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		var recoilPos = mousePos + Random.insideUnitCircle * .15f;
		Vector2 firePointPosition = transform.position;//new Vector2 (firePoint.position.x, firePoint.position.y)

		/*
		Vector2 dir = firePointPosition - mousePos;
		Ray2D r = new Ray2D (firePointPosition,dir);
		RaycastHit2D hit = Physics2D.Raycast(firePointPosition, dir, range);
		GameObject hitobject = hit.transform.gameObject;

		Vector2 endpos = r.GetPoint (range);
		endpos = mousePos;
		if(hitobject != null)
		{
			endpos = hit.point;
		}
		DrawLine (firePointPosition,endpos,Color.white, 0.1f);
*/
		if (canshoot)
		{
			DrawLine (firePointPosition,recoilPos,Color.white, 0.1f);
			RaycastHit2D hit = Physics2D.Linecast (firePointPosition, recoilPos);
			GameObject hitobject = hit.transform.gameObject;
			Debug.Log ("Player Hit : " + hitobject.transform.name);//hit.collider.name);
			if (hitobject != null && hitobject.GetComponent<Rigidbody2D> () != null && hitobject.tag != "Wall")
			{
				hitobject.GetComponent<Rigidbody2D> ().position = Vector2.MoveTowards(hitobject.transform.position, player.transform.position, (-knockback/5));
				hitobject.GetComponent<HealthComponent>().damage(30, gameObject.GetComponent<Unit>());
			}
		}




	}
}