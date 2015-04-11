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
		
		float buttonWidth = 30 * rx;
		float buttonHeight = 30 * ry;

		float boxWidth = 50 * rx;
		float boxHeight = 50 * ry;
		
		float offsetX1 = 75 * rx;
		float offsetX2 = 25 * rx;
		
		float offsetY1 = 75 * ry;
		float offsetY2 = 25 * ry;
		
		// Make a background box
		GUI.Box(new Rect(wantedPos.x-offsetX1,wantedPos.y-offsetY2,boxWidth,boxHeight),"");
		GUI.Box(new Rect(wantedPos.x+offsetX2,wantedPos.y-offsetY2,boxWidth,boxHeight),"");
		GUI.Box(new Rect(wantedPos.x-offsetX2,wantedPos.y-offsetY1,boxWidth,boxHeight),"");
		GUI.Box(new Rect(wantedPos.x-offsetX2,wantedPos.y+offsetY2,boxWidth,boxHeight),"");
		


		GUI.DrawTexture(new Rect(10 * rx+wantedPos.x-offsetX1,wantedPos.y-offsetY2,buttonWidth,buttonHeight) , textureMIEIC);
		GUI.Label(new Rect(15 * rx+wantedPos.x-offsetX1,30*ry+wantedPos.y-offsetY2,50*rx,20*ry),MIEICPrice.ToString());
		if(GUI.Button(new Rect(wantedPos.x-offsetX1,wantedPos.y-offsetY2,boxWidth,boxHeight),"", new GUIStyle())) {
			if(gCtrl.money>=MIEICPrice)
			{
				gCtrl.addMoney(-MIEICPrice);
				tileScript.setTowerPlacement(1);
			}
			enabled=false;
		}
		
		GUI.DrawTexture(new Rect(10 * rx+wantedPos.x+offsetX2,wantedPos.y-offsetY2,buttonWidth,buttonHeight) , textureMIEEC);
		GUI.Label(new Rect(15 * rx+wantedPos.x+offsetX2,30*ry+wantedPos.y-offsetY2,50*rx,20*ry),MIEECPrice.ToString());
		if(GUI.Button(new Rect(wantedPos.x+offsetX2,wantedPos.y-offsetY2,boxWidth,boxHeight), "", new GUIStyle())) {
			if(gCtrl.money>=MIEECPrice)
			{
				gCtrl.addMoney(-MIEECPrice);
				tileScript.setTowerPlacement(2);
			}
			enabled=false;
		}
		
		GUI.DrawTexture(new Rect(10 * rx+wantedPos.x-offsetX2,wantedPos.y-offsetY1,buttonWidth,buttonHeight) , textureLCEEMG);
		GUI.Label(new Rect(15 * rx+wantedPos.x-offsetX2,30*ry+wantedPos.y-offsetY1,50*rx,20*ry),LCEEMGPrice.ToString());
		if(GUI.Button(new Rect(wantedPos.x-offsetX2,wantedPos.y-offsetY1,boxWidth,boxHeight), "", new GUIStyle())) {
			if(gCtrl.money>=LCEEMGPrice)
			{
				gCtrl.addMoney(-LCEEMGPrice);
				tileScript.setTowerPlacement(3);
			}
			enabled=false;
		}
		
		GUI.DrawTexture(new Rect(10 * rx+wantedPos.x-offsetX2,wantedPos.y+offsetY2,buttonWidth,buttonHeight) , textureMIEQ);
		GUI.Label(new Rect(15 * rx+wantedPos.x-offsetX2,30*ry+wantedPos.y+offsetY2,50*rx,20*ry),MIEQPrice.ToString());
		if(GUI.Button(new Rect(wantedPos.x-offsetX2,wantedPos.y+offsetY2,boxWidth,boxHeight), "", new GUIStyle())) {
			if(gCtrl.money>=MIEQPrice)
			{
				gCtrl.addMoney(-MIEQPrice);
				tileScript.setTowerPlacement(4);
			}
			enabled=false;
		}
	}
}
