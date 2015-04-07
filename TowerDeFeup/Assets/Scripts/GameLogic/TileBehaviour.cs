using UnityEngine;
using System.Collections;

public class TileBehaviour : MonoBehaviour {

	public GameObject tower1;
	public GameObject tower2;
	public GameObject tower3;
	public GameObject tower4;
	private bool used=false;
	// Use this for initialization
	void Start () {
	
	}
	
	void OnMouseOver(){

		if (Input.GetMouseButtonDown (0)&&!used) {
			Instantiate (tower4, transform.position, Quaternion.identity);
			used = true;
		} else if (Input.GetMouseButtonDown (1)&&!used) {
			Instantiate (tower3, transform.position, Quaternion.identity);
			used=true;
		}

	}

	// Update is called once per frame
	void Update () {
	
	}
}
