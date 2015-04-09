using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseBehaviour : MonoBehaviour {
	
	public GameObject enemy;
	public float speed;
	
	private float width;// height;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Enemy") {
			EnemyBehaviour behaviour=other.gameObject.GetComponent<EnemyBehaviour> ();
			Destroy (gameObject);
			Destroy (other.transform.parent.gameObject);
			setHealth();
		}
	}
	
	void setHealth()
	{
		GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ().setHealth ();
	}
	
}
