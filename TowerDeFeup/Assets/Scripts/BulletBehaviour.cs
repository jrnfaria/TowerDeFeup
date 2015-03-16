﻿using UnityEngine;
using System.Collections;

public class BulletBehaviour : MonoBehaviour {

	public GameObject enemy;
	public float speed;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		float step = speed * Time.deltaTime;
		if (enemy != null)
			transform.position = Vector3.MoveTowards (transform.position, enemy.transform.position, step);
		else
			Destroy (gameObject);
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
	if (other.gameObject.tag == "Enemy") {
			EnemyBehaviour behaviour=other.gameObject.GetComponent<EnemyBehaviour> ();
			behaviour.health = other.gameObject.GetComponent<EnemyBehaviour> ().health - 20;
			Destroy (gameObject);
			if(behaviour.health<=0)
				Destroy (other.transform.parent.gameObject);
		}

	}

}
