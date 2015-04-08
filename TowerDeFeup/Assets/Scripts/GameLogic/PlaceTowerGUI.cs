using UnityEngine;
using System.Collections;

public class PlaceTowerGUI : MonoBehaviour {

	private Vector3 wantedPos;
	public GameObject tile;
	private TileBehaviour tileScript;

	// Use this for initialization
	void Start () {
		wantedPos = Camera.main.WorldToViewportPoint (transform.position);
		tileScript = GetComponent<TileBehaviour>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		// Make a background box
		GUI.Box(new Rect(wantedPos.x,wantedPos.y,100,90), "Loader Menu");
		
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(wantedPos.x+10,wantedPos.y+20,80,20), "MIEIC")) {
			tileScript.setTowerPlacement(1);
			enabled=false;
		}
		
		// Make the second button.
		if(GUI.Button(new Rect(wantedPos.x+10,wantedPos.y+40,80,20), "MIEEC")) {
			tileScript.setTowerPlacement(2);
			enabled=false;
		}

		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(wantedPos.x+10,wantedPos.y+60,80,20), "LCEEMG")) {
			tileScript.setTowerPlacement(3);
			enabled=false;
		}
		
		// Make the second button.
		if(GUI.Button(new Rect(wantedPos.x+10,wantedPos.y+80,80,20), "MIEQ")) {
			tileScript.setTowerPlacement(4);
			enabled=false;
		}
	}
}
