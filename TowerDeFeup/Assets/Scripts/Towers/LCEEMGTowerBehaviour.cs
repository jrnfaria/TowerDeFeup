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
	private GameController gameCtrl;
	
	// Use this for initialization
	void Start ()
	{
		gameCtrl = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController>();
		enemies=gameCtrl.getEnemies ();
		Invoke("CreateBullet",0.1f);
		
		rangeScript = range.GetComponent<TowerRangeBehaviour> ();
		rangeScript.setDistance (distance);
		rangeScript.setPosition (transform);
	}

	
	// Update is called once per frame
	void Update ()
	{
		
		enemies=gameCtrl.getEnemies ();
		
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
			if(shootedEnemy!=null)
			{
				if (Vector3.Distance (shootedEnemy.transform.position, transform.position) <= distance) {
					crack.GetComponent<CrackBehaviour> ().enemy = shootedEnemy;
					 Instantiate (crack, transform.position, Quaternion.identity);
				}
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
			if(enemy!=null)
			{
				Vector3 enemyPos = enemy.transform.position;
				float distanceSqr = Vector3.Distance(enemyPos, transform.position);
				
				if (distanceSqr < nearestDistanceSqr) {
					nearestObj = enemy;
					nearestDistanceSqr = distanceSqr;
				}
			}
		}
		shootedEnemy = nearestObj;
	}
}

