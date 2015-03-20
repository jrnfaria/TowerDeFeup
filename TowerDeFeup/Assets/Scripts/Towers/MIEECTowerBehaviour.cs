using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MIEECTowerBehaviour : MonoBehaviour {

	private TowerRangeBehaviour rangeScript;
	public GameObject range;

	private List<GameObject> enemies= new List<GameObject>();
	public float distance;
	public float timeBeetweenShoots;

	// Use this for initialization
	void Start () {
	
		rangeScript=range.GetComponent<TowerRangeBehaviour> ();
		rangeScript.setDistance (distance);
		rangeScript.setPosition (transform);

		getEnemies ();
		Invoke ("ThunderAttack", timeBeetweenShoots);
	}

	void ThunderAttack()
	{
		List<GameObject> inRangeEnemies = getInRangeEnemies ();

		foreach(GameObject enemy in inRangeEnemies)
		{
			EnemyBehaviour enemyScript=enemy.GetComponent<EnemyBehaviour>();
			enemyScript.health=enemyScript.health-1;

			if(enemyScript.health<=0)
			{
				Destroy (enemy.transform.parent.gameObject);
			}
		}

		Invoke ("ThunderAttack", timeBeetweenShoots);
	}

	void getEnemies()
	{
		enemies= new List<GameObject>();
		
		foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
		{
			enemies.Add(enemy);
		}

	}

	List<GameObject> getInRangeEnemies()
	{
		List<GameObject> rsp=new List<GameObject>();

		foreach (GameObject enemy in enemies) {
			Vector3 enemyPos = enemy.transform.position;
			float enemyDist = Vector3.Distance(enemyPos, transform.position);
			if (enemyDist < distance) {
				rsp.Add (enemy);
			}
		}
		return rsp;
	}
	
	// Update is called once per frame
	void Update () {
		getEnemies ();

	}

	void OnMouseEnter(){
		rangeScript.setRange(true);
	}
	
	void OnMouseExit(){
		rangeScript.setRange(false);
	}

}
