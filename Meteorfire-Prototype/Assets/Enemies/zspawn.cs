using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zspawn : MonoBehaviour {

	public bool canspawn;
	public GameObject Zombie;
	public Vector3 thepos;
	private GameObject[] enemySlots;

	// Use this for initialization
	void Start () {
		thepos = transform.position;
		StartCoroutine (spawnwave ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator spawnwave()
	{
		enemySlots = GameObject.FindGameObjectsWithTag ("Enemy");
		int count = enemySlots.Length;
		while (count < 30){
			Instantiate (Zombie,thepos, Quaternion.identity);
			yield return new WaitForSeconds (Random.Range(4f,8f));
	}
	//	StartCoroutine (spawnwave ());
	}
}
