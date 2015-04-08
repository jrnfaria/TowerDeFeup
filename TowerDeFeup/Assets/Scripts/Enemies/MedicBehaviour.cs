using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MedicBehaviour : MonoBehaviour {

	public float range;
	public int heal;
	public float timeBeetweenHeal;

	private List<GameObject> enemies = new List<GameObject> ();
	private List<GameObject> enemiesInRange = new List<GameObject> ();
	private GameController gameCtrl;


	// Use this for initialization
	void Start () {
		gameCtrl = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController>();
		enemies=gameCtrl.getEnemies ();
		InvokeRepeating ("healing",timeBeetweenHeal,timeBeetweenHeal);
	}



	void GetEnemiesInRange ()
	{
		enemiesInRange = new List<GameObject> ();
		// loop through each tagged object, remembering nearest one found
		foreach (GameObject enemy in enemies) {
			if (enemy!=null)
			{
				Vector3 enemyPos = enemy.transform.position;
				float distanceSqr = Vector3.Distance(enemyPos, transform.position);
				
				if (distanceSqr < range) {
					enemiesInRange.Add (enemy);
				}
			}
		}

	}

	void healing()
	{
		GetEnemiesInRange ();
		int health = 0;
		int maxHealth = 0;
		
		foreach (GameObject enemy in enemiesInRange) {
			if(enemy!=null)
				{
				health=enemy.GetComponent<EnemyBehaviour>().health;
				maxHealth=enemy.GetComponent<EnemyBehaviour>().maxHealth;
				
				if(health<maxHealth)
				{
					enemy.GetComponent<EnemyBehaviour>().health=Mathf.Clamp(health+heal,0,maxHealth);
				}
			}
		}
	}
	// Update is called once per frame
	void Update () {
		enemies=gameCtrl.getEnemies ();
	}
}
