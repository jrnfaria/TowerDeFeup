using UnityEngine;
using System.Collections;

public class CrackBehaviour : MonoBehaviour {
	
	public GameObject enemy;
	public float speed;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//float step = speed * Time.deltaTime;
		StartCoroutine(FadeTo(0.0f, 3.0f));
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Enemy") {
			EnemyBehaviour behaviour=other.gameObject.GetComponent<EnemyBehaviour> ();
			behaviour.health = other.gameObject.GetComponent<EnemyBehaviour> ().health - 200;
			if(behaviour.health<=0)
			{
				GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ().addMoney (other.GetComponent<EnemyBehaviour>().money);
				Destroy (other.transform.parent.gameObject);
			}
		}
		
	}

	public IEnumerator FadeTo(float aValue, float aTime)
	{
		float alpha = this.GetComponent<Renderer>().material.color.a;
		for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
		{
			Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha,aValue,t));
			this.GetComponent<Renderer>().material.color = newColor;
			if(t>=0.9f){
				Destroy(this.gameObject);
			}
			yield return null;
		}
	}
	
}
