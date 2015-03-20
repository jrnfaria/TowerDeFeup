using UnityEngine;
using System.Collections;

public class TowerRangeBehaviour : MonoBehaviour {


	private float dist;
	private GUITexture texture;
	private bool showRange;
	
	void Start () {
		texture = GetComponent<GUITexture> ();
		showRange = false;
	}

	public void setDistance(float d)
	{
		dist = d;
		transform.localScale = new Vector3 (dist/11f,dist*2/11f, 0);
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
