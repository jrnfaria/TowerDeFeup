using UnityEngine;
using System.Collections;

public class TowerRangeBehaviour : MonoBehaviour {


	private float dist;
	private GUITexture texture;
	private bool showRange;

	private float rx;
	private float ry;
	
	void Start () {
		texture = GetComponent<GUITexture> ();
		showRange = false;
		rx = Screen.width / 1280.0f; //or whatever with do you want;
		ry = Screen.height / 720.0f;

		Debug.Log (rx);
		Debug.Log (ry);
	}

	public void setDistance(float d)
	{
		dist = d;
		transform.localScale = new Vector3 (dist/12f,dist/12f*2, 0);
	}

	public void setRange(bool s)
	{
		showRange = s;
	}

	public void setPosition(Transform t)
	{
		var wantedPos = Camera.main.WorldToViewportPoint (t.position);
		transform.position = wantedPos;
	}

	// Update is called once per frame
	void Update () {

		if(showRange)
			texture.enabled=true;
		else
			texture.enabled=false;

	}
}
