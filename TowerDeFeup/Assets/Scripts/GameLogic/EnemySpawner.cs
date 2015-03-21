using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemy;
	private int count=0;
	private int enemyNo;

	// Use this for initialization
	void Start () {
		enemyNo = this.GetComponent<XmlReader> ().container.waves[0].content[0].quantity;
		Invoke ("SpawnEnemy", 2);
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void SpawnEnemy(){
		if (count < enemyNo) {
			Instantiate (enemy, transform.position, Quaternion.identity);
			count++;
			Invoke ("SpawnEnemy", 2);
		}
	}
}
