using UnityEngine;

public class Enemy : Unit {
	public GameObject target;

	public float aggrorange;
	private Rigidbody2D rb;
	public Transform tf;


	public HealthComponent tempHealth; 

	public int gold;

	public bool is_idle;

	// TODO sometimes the enemy might want to target the base instead of the player
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player");
		rb = GetComponent<Rigidbody2D> ();
		is_idle = false;
		//tf.position.z = 0;
	}
	
	void Update () {
		//if (idle) {
			//if the player is close enough then run towards him at variable speed
			if (Vector2.Distance (gameObject.transform.position, target.transform.position) < aggrorange) {
				rb.position = Vector2.MoveTowards (gameObject.transform.position, target.transform.position, maxspeed * Time.deltaTime);
				//rb.velocity = (Vector2.MoveTowards (gameObject.transform.position, target.transform.position, movespeed * Time.deltaTime) * -1);
		
				//rotate towards player
				transform.rotation = Quaternion.LookRotation (Vector3.forward, target.transform.position - transform.position);

				// if(rb.velocity.magnitude > maxspeed) {
					//rb.velocity = rb.velocity.normalized * maxspeed;
				//	}
			}
		//} else { }
	}

	// TODO perhaps the enemy can actually target structures instead of colliding with them
	void OnCollisionStay2D(Collision2D col) {
		if (col.gameObject.tag == "Player" || col.gameObject.tag == "Wall") {
			col.gameObject.GetComponent<HealthComponent>().damage(1, gameObject.GetComponent<Unit>());

			//col.gameObject.GetComponent<HealthComponent> ().takeDam (100);
			gold++;
		}
			
		Debug.Log (col.gameObject.name);
	}
}
			