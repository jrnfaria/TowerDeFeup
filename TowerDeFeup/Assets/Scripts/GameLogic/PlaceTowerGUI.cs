using UnityEngine;
using System.Collections;

public class PlaceTowerGUI : MonoBehaviour {

	private Vector3 wantedPos;
	private TileBehaviour tileScript;
	public Texture2D textureMIEIC;
	public Texture2D textureMIEEC;
	public Texture2D textureLCEEMG;
	public Texture2D textureMIEQ;

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
		GUI.Box(new Rect(wantedPos.x,wantedPos.y,100,100),"");
		
		GUI.DrawTexture(new Rect(wantedPos.x,wantedPos.y,45,45) , textureMIEIC);
		if(GUI.Button(new Rect(wantedPos.x+10,wantedPos.y+20,80,20), "", new GUIStyle())) {
			tileScript.setTowerPlacement(1);
			enabled=false;
		}
		
		GUI.DrawTexture(new Rect(wantedPos.x+55,wantedPos.y,45,45) , textureMIEEC);
		if(GUI.Button(new Rect(wantedPos.x+55,wantedPos.y,45,45), "", new GUIStyle())) {
			tileScript.setTowerPlacement(2);
			enabled=false;
		}
		
		GUI.DrawTexture(new Rect(wantedPos.x,wantedPos.y+55,45,45) , textureLCEEMG);
		if(GUI.Button(new Rect(wantedPos.x,wantedPos.y+55,45,45), "", new GUIStyle())) {
			tileScript.setTowerPlacement(3);
			enabled=false;
		}
		
		GUI.DrawTexture(new Rect(wantedPos.x+55,wantedPos.y+55,45,45) , textureMIEQ);
		if(GUI.Button(new Rect(wantedPos.x+55,wantedPos.y+55,45,45), "MIEQ", new GUIStyle())) {
			tileScript.setTowerPlacement(4);
			enabled=false;
		}
	}
}
