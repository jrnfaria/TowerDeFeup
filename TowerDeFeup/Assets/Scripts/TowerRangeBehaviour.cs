using UnityEngine;
using System.Collections;

public class TowerRangeBehaviour : MonoBehaviour {

	public GameObject tower;
	private TowerBehaviour script;
	private float dist;
	private GUITexture texture;
	
	void Start () {
		script = tower.GetComponent<TowerBehaviour> ();
		dist = script.distance;
		texture = GetComponent<GUITexture> ();

		var wantedPos = Camera.main.WorldToViewportPoint (tower.transform.position);
		transform.position = wantedPos;

		transform.localScale = new Vector3 (dist/10,dist*2/10, 0);
	}
	
	// Update is called once per frame
	void Update () {

		if(script.drawRange)
			texture.enabled=true;
		else
			texture.enabled=false;

	}
}
