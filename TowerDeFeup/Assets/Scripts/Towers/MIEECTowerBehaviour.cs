using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MIEECTowerBehaviour : Tower
{
	
	private TowerRangeBehaviour rangeScript;
	public GameObject range;
	private List<GameObject> enemies = new List<GameObject> ();
	private GameObject shootedEnemy;
	public float speed;
	public GameObject spark;
	private GameObject spark2;
	public float distance;
	public float width, height;
	private GameController gameCtrl;

	//upgrade tower
	private int towerLevel;
	private UpgradeTowerGUI gui;
	public Sprite lvl2;
	public Sprite lvl3;
	public float improvePercentage;


	// Use this for initialization
	void Start ()
	{
		gameCtrl = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController>();
		enemies=gameCtrl.getEnemies ();
		
		rangeScript = range.GetComponent<TowerRangeBehaviour> ();
		rangeScript.setDistance (distance);
		rangeScript.setPosition (transform);

		gui = GetComponent<UpgradeTowerGUI>();
		gui.enabled = false;
		towerLevel = 1;
	}
	

	
	// Update is called once per frame
	void Update ()
	{
		
		enemies=gameCtrl.getEnemies ();
		
		if (enemies.Count > 0) {
			GameObject oldShooted = shootedEnemy;
			GetNearestEnemy ();
			RotateTower ();
			if (oldShooted != shootedEnemy) {
				Destroy(spark2);
				CreateBullet ();
			}
		}
	}

	public override void upgrade()
	{
		towerLevel++;
		if(towerLevel==2)
			GetComponent<SpriteRenderer> ().sprite = lvl2;
		else if(towerLevel==3)
			GetComponent<SpriteRenderer> ().sprite = lvl3;
	}

	public override int getTowerLevel()
	{
		return towerLevel;
	}

	void OnMouseOver(){
		
		if (Input.GetMouseButtonDown (0)) {
			closeInterfaces();
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

	void OnDestroy() {
		DestroyImmediate (spark,true);
		DestroyImmediate (spark2,true);
	}

	public void CreateBullet ()
	{
		if (enemies.Count > 0) {
			if (Vector3.Distance (shootedEnemy.transform.position, transform.position) <= distance) {
				spark.GetComponent<SparkBehaviour> ().enemy = shootedEnemy;
				spark2 = Instantiate (spark, transform.position, Quaternion.identity)as GameObject;
			}else{
				Invoke("CreateBullet",0.1f);
			}
		}
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
			} else {
				transform.rotation = Quaternion.RotateTowards (transform.rotation, Quaternion.identity, speed * Time.deltaTime);
				Destroy (spark2);
			}
		}
	}
}
