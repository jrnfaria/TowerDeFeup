using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SparkBehaviour : MonoBehaviour {
	
	public GameObject enemy;
	public float speed;

	private MIEECTowerBehaviour towerB;
	
	// Use this for initialization
	void Start () {
		RotateSpark ();
	}
	
	// Update is called once per frame
	void Update () {
		float step = speed * Time.deltaTime;
		if (enemy != null) {
			transform.position = Vector3.MoveTowards (transform.position, enemy.transform.position, step);
			RotateSpark ();
		} else {
			Destroy (gameObject);
		}
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Enemy") {
			EnemyBehaviour behaviour=other.gameObject.GetComponent<EnemyBehaviour> ();
			behaviour.health = other.gameObject.GetComponent<EnemyBehaviour> ().health - 30;
			Destroy (gameObject);
			if(behaviour.health<=0)
				Destroy (other.transform.parent.gameObject);
		}
		
	}

	void RotateSpark ()
	{
		if (Vector3.Distance (enemy.transform.position, transform.position) <= 2/*towerB.distance*/) {
			Vector3 vectorToTarget = enemy.transform.position - transform.position;
			float angle = Mathf.Atan2 (vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
			Quaternion q = Quaternion.AngleAxis (angle, Vector3.forward);
			transform.rotation = Quaternion.RotateTowards (transform.rotation, q, 360*10 * Time.deltaTime); 
		} else
			transform.rotation = Quaternion.RotateTowards (transform.rotation, Quaternion.identity, 360*10 * Time.deltaTime); 
	}
	
}
