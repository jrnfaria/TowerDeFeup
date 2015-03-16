using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TowerBehaviour : MonoBehaviour {

	private List<GameObject> enemies= new List<GameObject>();
	public float speed;
	public GameObject bullet;
	public float distance;

	// Use this for initialization
	void Start () {
		foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
		{
			enemies.Add(enemy);
		}

		Invoke("CreateBullet", 2.0f);
	}

	void CreateBullet()
	{
		if (enemies.Count > 0) {
			if(Vector3.Distance(enemies[0].transform.position, transform.position)<=distance)
			{
			bullet.GetComponent<BulletBehaviour> ().enemy = enemies [0];
			Instantiate (bullet, transform.position, Quaternion.identity);

			Invoke ("CreateBullet", 2.0f);
			}
		}

	}

	void OnMouseOver(){
		bullet.GetComponent<BulletBehaviour> ().enemy = enemies [0];
		Instantiate (bullet, transform.position, Quaternion.identity);
	}

	// Update is called once per frame
	void Update () {

		enemies= new List<GameObject>();

		foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
		{
			enemies.Add(enemy);
		}

		if (enemies.Count > 0) {
			RotateTower ();
		}
	}

	void RotateTower()
	{
		Vector3 vectorToTarget = enemies[0].transform.position - transform.position;
		float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg+90;
		Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
		transform.rotation = Quaternion.RotateTowards (transform.rotation, q, speed * Time.deltaTime); 
	}
}
