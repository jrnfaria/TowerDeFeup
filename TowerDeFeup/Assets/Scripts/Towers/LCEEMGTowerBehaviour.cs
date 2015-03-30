using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LCEEMGTowerBehaviour : MonoBehaviour
{
	
	private TowerRangeBehaviour rangeScript;
	public GameObject range;
	private List<GameObject> enemies = new List<GameObject> ();
	private GameObject shootedEnemy;
	public float speed;
	public GameObject crack;
	private GameObject crack2;
	public float distance;
	public float width, height;
	
	// Use this for initialization
	void Start ()
	{
		
		getEnemies ();
		Invoke("CreateBullet",0.1f);
		
		rangeScript = range.GetComponent<TowerRangeBehaviour> ();
		rangeScript.setDistance (distance);
		rangeScript.setPosition (transform);
	}
	
	void getEnemies ()
	{
		enemies = new List<GameObject> ();
		
		foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy")) {
			enemies.Add (enemy);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		getEnemies ();
		
		if (enemies.Count > 0) {
			GetNearestEnemy ();
		}
	}
	
	void OnMouseEnter ()
	{
		rangeScript.setRange (true);
	}
	
	void OnMouseExit ()
	{
		rangeScript.setRange (false);
	}
	
	public void CreateBullet ()
	{
		if (enemies.Count > 0) {
			if (Vector3.Distance (shootedEnemy.transform.position, transform.position) <= distance) {
				crack.GetComponent<CrackBehaviour> ().enemy = shootedEnemy;
				crack2 = Instantiate (crack, transform.position, Quaternion.identity)as GameObject;
			}
		}
		Invoke("CreateBullet",3);
	}
	
	void GetNearestEnemy ()
	{
		float nearestDistanceSqr = Mathf.Infinity;
		GameObject nearestObj = null;
		
		// loop through each tagged object, remembering nearest one found
		foreach (GameObject enemy in enemies) {
			Vector3 enemyPos = enemy.transform.position;
			float distanceSqr = Vector3.Distance(enemyPos, transform.position);
			
			if (distanceSqr < nearestDistanceSqr) {
				nearestObj = enemy;
				nearestDistanceSqr = distanceSqr;
			}
		}
		shootedEnemy = nearestObj;
	}
}

