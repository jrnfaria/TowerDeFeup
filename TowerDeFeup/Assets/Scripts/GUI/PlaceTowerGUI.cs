using UnityEngine;
using System.Collections;

public class PlaceTowerGUI : MonoBehaviour {
	
	private Vector3 wantedPos;
	private TileBehaviour tileScript;

	public Texture2D textureMIEIC;
	public Texture2D textureMIEEC;
	public Texture2D textureLCEEMG;
	public Texture2D textureMIEQ;

	public int MIEICPrice;
	public int MIEECPrice;
	public int LCEEMGPrice;
	public int MIEQPrice;

	private GameController gCtrl;
	
	// Use this for initialization
	void Start () {

		wantedPos = Camera.main.WorldToScreenPoint(transform.position);
		wantedPos = new Vector3 (wantedPos.x, Screen.height-wantedPos.y , wantedPos.z);
		tileScript = GetComponent<TileBehaviour>();
		gCtrl = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
	}
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI () {

		float rx = Screen.width / 1280.0f; //or whatever with do you want;
		float ry = Screen.height / 720.0f; //or whatever height do you want;
		
		float buttonWidht = 50 * rx;
		float buttonHeight = 50 * ry;
		
		float offsetX1 = 75 * rx;
		float offsetX2 = 25 * rx;
		
		float offsetY1 = 75 * ry;
		float offsetY2 = 25 * ry;
		
		// Make a background box
		GUI.Box(new Rect(wantedPos.x-offsetX1,wantedPos.y-offsetY2,buttonWidht,buttonHeight),"");
		GUI.Box(new Rect(wantedPos.x+offsetX2,wantedPos.y-offsetY2,buttonWidht,buttonHeight),"");
		GUI.Box(new Rect(wantedPos.x-offsetX2,wantedPos.y-offsetY1,buttonWidht,buttonHeight),"");
		GUI.Box(new Rect(wantedPos.x-offsetX2,wantedPos.y+offsetY2,buttonWidht,buttonHeight),"");
		


		GUI.DrawTexture(new Rect(wantedPos.x-offsetX1,wantedPos.y-offsetY2,buttonWidht,buttonHeight) , textureMIEIC);
		if(GUI.Button(new Rect(wantedPos.x-offsetX1,wantedPos.y-offsetY2,buttonWidht,buttonHeight), "", new GUIStyle())) {
			if(gCtrl.money>=MIEICPrice)
			{
				gCtrl.addMoney(-MIEICPrice);
				tileScript.setTowerPlacement(1);
			}
			enabled=false;
		}
		
		GUI.DrawTexture(new Rect(wantedPos.x+offsetX2,wantedPos.y-offsetY2,buttonWidht,buttonHeight) , textureMIEEC);
		if(GUI.Button(new Rect(wantedPos.x+offsetX2,wantedPos.y-offsetY2,buttonWidht,buttonHeight), "", new GUIStyle())) {
			if(gCtrl.money>=MIEECPrice)
			{
				gCtrl.addMoney(-MIEECPrice);
				tileScript.setTowerPlacement(2);
			}
			enabled=false;
		}
		
		GUI.DrawTexture(new Rect(wantedPos.x-offsetX2,wantedPos.y-offsetY1,buttonWidht,buttonHeight) , textureLCEEMG);
		if(GUI.Button(new Rect(wantedPos.x-offsetX2,wantedPos.y-offsetY1,buttonWidht,buttonHeight), "", new GUIStyle())) {
			if(gCtrl.money>=LCEEMGPrice)
			{
				gCtrl.addMoney(-LCEEMGPrice);
				tileScript.setTowerPlacement(3);
			}
			enabled=false;
		}
		
		GUI.DrawTexture(new Rect(wantedPos.x-offsetX2,wantedPos.y+offsetY2,buttonWidht,buttonHeight) , textureMIEQ);
		if(GUI.Button(new Rect(wantedPos.x-offsetX2,wantedPos.y+offsetY2,buttonWidht,buttonHeight), "", new GUIStyle())) {
			if(gCtrl.money>=MIEQPrice)
			{
				gCtrl.addMoney(-MIEQPrice);
				tileScript.setTowerPlacement(4);
			}
			enabled=false;
		}
	}
}
