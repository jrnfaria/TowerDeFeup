using UnityEngine;
using System.Collections;
using System.Collections.Generic;

abstract public class Tower:MonoBehaviour {


	public virtual void upgrade()
	{
	}

	public virtual int getTowerLevel()
	{
		return 0;
	}
 
	public void closeInterfaces()
	{
		GameObject[] tiles = GameObject.FindGameObjectsWithTag ("Tile");
		for(int i=0;i<tiles.Length;i++ )
		{
			tiles[i].GetComponent<PlaceTowerGUI>().enabled=false;
		}

		GameObject[] towers = GameObject.FindGameObjectsWithTag ("Tower");
		for(int i=0;i<towers.Length;i++ )
		{
			towers[i].GetComponent<UpgradeTowerGUI>().enabled=false;
		}
	}
 }
 
public class TowerBehaviour : Tower
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
		towerLevel = 1;

		gui = GetComponent<UpgradeTowerGUI>();
		gui.enabled = false;
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

	// Update is called once per frame
	void Update ()
	{
		
		enemies=gameCtrl.getEnemies ();
		
		if (enemies.Count > 0) {
			GetNearestEnemy ();
			RotateTower ();
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
					GameObject b=Instantiate (bullet, transform.position, Quaternion.identity) as GameObject;
					b.GetComponent<BulletBehaviour>().damage+=(int)(b.GetComponent<BulletBehaviour>().damage*improvePercentage*towerLevel);
				}
			}
		}
		Invoke ("CreateBullet", timeBeetweenShoots*(1-improvePercentage*(towerLevel-1)));
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
