using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {
	
	public GameObject enemy;
	private EnemyBehaviour enemyScript;
	private int lastHealth;
	private int maxHealth;
	private float initialScaleX;

	void Start () {
		enemyScript = enemy.GetComponent<EnemyBehaviour> ();
		lastHealth = enemyScript.health;
		maxHealth = enemyScript.maxHealth;
		initialScaleX = transform.localScale.x;
	}
	
	// Update is called once per frame

	
	void Update ()
	{
		var wantedPos = Camera.main.WorldToViewportPoint (enemy.transform.position);
		transform.position = wantedPos;

		lastHealth = enemyScript.health;
		transform.localScale = new Vector3 ((initialScaleX*lastHealth) /maxHealth,(float) 0.07, 0);
	}
	
}
