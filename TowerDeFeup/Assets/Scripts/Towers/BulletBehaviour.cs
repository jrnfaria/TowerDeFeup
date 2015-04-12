using UnityEngine;
using System.Collections;

public class BulletBehaviour : MonoBehaviour {

	public GameObject enemy;
	public float speed;
	public int damage;

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
			behaviour.health = other.gameObject.GetComponent<EnemyBehaviour> ().health - damage;
			Destroy (gameObject);
			if(behaviour.health<=0 && !behaviour.isDead())
			{
				GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ().addMoney (other.GetComponent<EnemyBehaviour>().money);
				behaviour.setDead(true);
				Destroy (other.transform.parent.gameObject);
			}
		}

	}

}
