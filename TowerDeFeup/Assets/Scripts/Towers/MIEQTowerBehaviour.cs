using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MIEQTowerBehaviour : Tower
{
	
	private TowerRangeBehaviour rangeScript;
	public GameObject range;
	private List<GameObject> enemies = new List<GameObject> ();
	private GameObject shootedEnemy;
	public float speed;
	public float timeBeetweenShoots;
	public GameObject gosma;
	public float distance;
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
		
		Invoke ("CreateBullet", timeBeetweenShoots);
		
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
			GetNearestEnemy ();
			RotateTower ();
		}
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

	void CreateBullet ()
	{
		if (enemies.Count > 0) {
			if(shootedEnemy!=null)
			{
				if (Vector3.Distance (shootedEnemy.transform.position, transform.position) <= distance) {
					gosma.GetComponent<GosmaBehaviour> ().enemy = shootedEnemy;
					GameObject g= Instantiate(gosma, transform.position, Quaternion.identity) as GameObject;
					g.GetComponent<GosmaBehaviour>().slow*=towerLevel;
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
			}
		}
	}
	
	void OnDestroy(){
		Destroy (range);
	}
}
