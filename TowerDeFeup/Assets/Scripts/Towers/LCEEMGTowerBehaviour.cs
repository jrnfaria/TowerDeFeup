using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LCEEMGTowerBehaviour : Tower
{
	
	private TowerRangeBehaviour rangeScript;
	public GameObject range;
	private List<GameObject> enemies = new List<GameObject> ();
	private GameObject shootedEnemy;
	public float speed;
	public float timeBeetweenShoots=3f;
	public GameObject crack;
	private GameObject crack2;
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
		Invoke("CreateBullet",0.1f);
		
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

	public override void upgrade()
	{
		towerLevel++;
		if(towerLevel==2)
			GetComponent<Animator> ().SetInteger("lvl",2);
		else if(towerLevel==3)
			GetComponent<Animator> ().SetInteger("lvl",3);
	}
	
	public override int getTowerLevel()
	{
		return towerLevel;
	}

	public void CreateBullet ()
	{
		if (enemies.Count > 0) {
			if(shootedEnemy!=null)
			{
				if (Vector3.Distance (shootedEnemy.transform.position, transform.position) <= distance) {
					crack.GetComponent<CrackBehaviour> ().enemy = shootedEnemy;
					GameObject c= Instantiate(crack, transform.position, Quaternion.identity) as GameObject;
					c.GetComponent<CrackBehaviour>().damage+=(int)(c.GetComponent<CrackBehaviour>().damage*improvePercentage*(towerLevel-1));
				}
			}
		}
		Invoke("CreateBullet",timeBeetweenShoots*(1-(improvePercentage*(towerLevel-1))));
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

