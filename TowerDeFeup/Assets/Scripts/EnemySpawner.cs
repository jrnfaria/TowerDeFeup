using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemy;

	// Use this for initialization
	void Start () {
		Instantiate (enemy, transform.position, Quaternion.identity);
		
		//container.waves[0].content[0].quantity;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
