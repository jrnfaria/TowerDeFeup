using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TowerBehaviour : MonoBehaviour {

	private List<GameObject> enemies= new List<GameObject>();
	private GameObject shootedEnemy;
	public float speed;
	public float timeBeetweenShoots;
	public GameObject bullet;
	public float distance;

	// Use this for initialization
	void Start () {
		foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
		{
			enemies.Add(enemy);
		}

		Invoke("CreateBullet", timeBeetweenShoots);
	}

	// Update is called once per frame
	void Update () {
		
		enemies= new List<GameObject>();
		
		foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
		{
			enemies.Add(enemy);
		}
		
		if (enemies.Count > 0) {
			GetNearestEnemy();
			RotateTower ();
		}
	}



	void CreateBullet()
	{
		if (enemies.Count > 0) {
			if(Vector3.Distance(shootedEnemy.transform.position, transform.position)<=distance)
			{
				bullet.GetComponent<BulletBehaviour> ().enemy = shootedEnemy;
			Instantiate (bullet, transform.position, Quaternion.identity);
			}
		}
		Invoke ("CreateBullet", timeBeetweenShoots);
	}

	void GetNearestEnemy()
	{
		float nearestDistanceSqr = Mathf.Infinity;
		GameObject nearestObj= null;
 
 // loop through each tagged object, remembering nearest one found
	foreach (GameObject obj in enemies) {
     Vector3 objectPos = obj.transform.position;
     float distanceSqr = (objectPos - transform.position).sqrMagnitude;
 
     if (distanceSqr < nearestDistanceSqr) {
         nearestObj = obj;
         nearestDistanceSqr = distanceSqr;
		 }
		}
		shootedEnemy=nearestObj;
	}






	void RotateTower()
	{
		if (Vector3.Distance (shootedEnemy.transform.position, transform.position) <= distance) {
			Vector3 vectorToTarget = shootedEnemy.transform.position - transform.position;
			float angle = Mathf.Atan2 (vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg + 90;
			Quaternion q = Quaternion.AngleAxis (angle, Vector3.forward);
			transform.rotation = Quaternion.RotateTowards (transform.rotation, q, speed * Time.deltaTime); 
		}
		else
			transform.rotation = Quaternion.RotateTowards (transform.rotation, Quaternion.identity, speed * Time.deltaTime); 
	}
}
