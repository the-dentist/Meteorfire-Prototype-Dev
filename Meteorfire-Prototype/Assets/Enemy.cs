using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : Unit {
	//public float speed;
	public GameObject target;
	public float aggrorange;
	private Rigidbody2D rb;
	public HealthComponent tempHealth; 
	public Transform tf;
	public int gold;
	public bool idle;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player");
		rb = GetComponent<Rigidbody2D> ();
		idle = false;
		//tf.position.z = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//if (idle) 
		{
			//if the player is close enough then run towards him at variable speed
			if (Vector2.Distance (gameObject.transform.position, target.transform.position) < aggrorange) {
				{
					rb.position = Vector2.MoveTowards (gameObject.transform.position, target.transform.position, maxspeed * Time.deltaTime);
					//rb.velocity = (Vector2.MoveTowards (gameObject.transform.position, target.transform.position, movespeed * Time.deltaTime) * -1);
					//rotate towards player
					transform.rotation = Quaternion.LookRotation (Vector3.forward, target.transform.position - transform.position);

					//if(rb.velocity.magnitude > maxspeed)
					{
						//rb.velocity = rb.velocity.normalized * maxspeed;
					}
				}
			}
		}
		//else
		{
			
		}
	}
	void OnCollisionStay2D(Collision2D col)
	{
		
		if (col.gameObject.tag == "Player" || col.gameObject.tag == "Wall")
		{
			col.gameObject.GetComponent<HealthComponent>().takeDam(1);

			//col.gameObject.GetComponent<HealthComponent> ().takeDam (100);
			gold++;
		}



		Debug.Log (col.gameObject.name);
			
	}
}
			