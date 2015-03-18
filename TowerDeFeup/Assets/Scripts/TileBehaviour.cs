using UnityEngine;
using System.Collections;

public class TileBehaviour : MonoBehaviour {

	public GameObject tower;
	// Use this for initialization
	void Start () {
	
	}
	
	void OnMouseOver(){

		if (Input.GetMouseButtonDown(0))
		Instantiate (tower, transform.position, Quaternion.identity);


	}

	// Update is called once per frame
	void Update () {
	
	}
}
