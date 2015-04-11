using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SparkBehaviour : MonoBehaviour {
	
	public GameObject enemy;
	public float speed;
	public int damage;

	private float width;// height;
	private Vector3 initialPos;
	
	// Use this for initialization
	void Start () {

		if (enemy != null) {
			initialPos=transform.position;
		}		
	}
	
	// Update is called once per frame
	void Update () {
		setWidthAndHeight ();

		if (enemy != null) {
			SetTarget (enemy.transform.position);
		} else {
			Destroy (gameObject);
		}
	}

	void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.tag == "Enemy") {
			EnemyBehaviour behaviour=other.gameObject.GetComponent<EnemyBehaviour> ();
			behaviour.health = other.gameObject.GetComponent<EnemyBehaviour> ().health - damage;
			if(behaviour.health<=0){
				GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ().addMoney (other.GetComponent<EnemyBehaviour>().money);
				Destroy (gameObject);
				Destroy (other.transform.parent.gameObject);
			}
		}
	}

	void setWidthAndHeight(){
		SpriteRenderer sr=GetComponent<SpriteRenderer>();
		if(sr==null) return;
		width=sr.sprite.bounds.size.x;
		//height=sr.sprite.bounds.size.y;
	}

	void SetTarget(Vector3 target)
	{
		var dir = target - initialPos;
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		transform.localScale = new Vector3(dir.magnitude/width,1,0);

		Bounds bounds = GetComponent<SpriteRenderer>().bounds;
		if (angle < 0) {
			angle = 360 + angle;
		}
		if (angle >= 0 && angle < 90) {
			transform.position = initialPos + new Vector3 (bounds.size.x/2, bounds.size.y/2, 0);
		} else if (angle >= 90 && angle < 180) {
			transform.position = initialPos + new Vector3 (-bounds.size.x/2, bounds.size.y/2, 0);
		} else if (angle >= 180 && angle < 270) {
			transform.position = initialPos + new Vector3 (-bounds.size.x/2, -bounds.size.y/2, 0);
		} else if (angle >= 270 && angle < 360) {
			transform.position = initialPos + new Vector3 (bounds.size.x/2, -bounds.size.y/2, 0);
		}

	}
	
}
