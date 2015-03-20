using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemy;
	private int count=0;
	private int enemyNo;

	// Use this for initialization
	void Start () {
		this.GetComponent<XmlReader> ().read();
		Container container = this.GetComponent<XmlReader>().container;
		
		enemyNo = container.waves [0].content [0].quantity;
	}
	
	// Update is called once per frame
	void Update () {
		if (count <= enemyNo) {
			Instantiate (enemy, transform.position, Quaternion.identity);
			count++;
		}
	}
}
