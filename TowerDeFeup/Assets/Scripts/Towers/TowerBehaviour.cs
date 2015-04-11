using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TowerBehaviour : MonoBehaviour
{

	private TowerRangeBehaviour rangeScript;
	public GameObject range;
	private List<GameObject> enemies = new List<GameObject> ();
	private GameObject shootedEnemy;
	public float speed;
	public float timeBeetweenShoots;
	public GameObject bullet;
	public float distance;
	private GameController gameCtrl;

	//upgrade tower
	private int towerLevel;
	public float improvePercentage;
	private UpgradeTowerGUI gui;

	// Use this for initialization
	void Start ()
	{

		gameCtrl = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController>();
		enemies=gameCtrl.getEnemies ();
		Invoke ("CreateBullet", timeBeetweenShoots);

		rangeScript = range.GetComponent<TowerRangeBehaviour> ();
		rangeScript.setDistance (distance);
		rangeScript.setPosition (transform);
		towerLevel = 1;

		gui = GetComponent<UpgradeTowerGUI>();
		gui.enabled = false;
	}

	// Update is called once per frame
	void Update ()
	{
		
		enemies=gameCtrl.getEnemies ();
		
		if (enemies.Count > 0) {
			GetNearestEnemy ();
			RotateTower ();
		}
	}

	void OnMouseOver(){
		
		if (Input.GetMouseButtonDown (0)) {
			gui.enabled = true;
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

	void CreateBullet ()
	{
		if (enemies.Count > 0) {
			if(shootedEnemy!=null)
			{
				if (Vector3.Distance (shootedEnemy.transform.position, transform.position) <= distance) {
					bullet.GetComponent<BulletBehaviour> ().enemy = shootedEnemy;
					Instantiate (bullet, transform.position, Quaternion.identity);
				}
			}
		}
		Invoke ("CreateBullet", timeBeetweenShoots);
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

	void RotateTower ()
	{
		if (shootedEnemy != null) {
			if (Vector3.Distance (shootedEnemy.transform.position, transform.position) <= distance) {
				Vector3 vectorToTarget = shootedEnemy.transform.position - transform.position;
				float angle = Mathf.Atan2 (vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg + 90;
				Quaternion q = Quaternion.AngleAxis (angle, Vector3.forward);
				transform.rotation = Quaternion.RotateTowards (transform.rotation, q, speed * Time.deltaTime); 
			} else
				transform.rotation = Quaternion.RotateTowards (transform.rotation, Quaternion.identity, speed * Time.deltaTime); 
		}
	}
}
