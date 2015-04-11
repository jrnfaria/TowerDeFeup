﻿using UnityEngine;
using System.Collections;

public class UpgradeTowerGUI : MonoBehaviour {

	private Vector3 wantedPos;
	public Texture2D textureUpgrade;
	public Texture2D textureSell;

	// Use this for initialization
	void Start () {
		wantedPos = Camera.main.WorldToScreenPoint(transform.position);
		wantedPos = new Vector3 (wantedPos.x, Screen.height-wantedPos.y , wantedPos.z);
		//tileScript = GetComponent<TileBehaviour>();
	}
	
	void OnGUI () {
		float rx = Screen.width / 1280.0f; //or whatever with do you want;
		float ry = Screen.height / 720.0f; //or whatever height do you want;
		
		float buttonWidht = 50 * rx;
		float buttonHeight = 50 * ry;

		float offsetY1 = 75 * ry;
		float offsetY2 = 25 * ry;

		float offsetX2 = 25 * rx;

		GUI.Box(new Rect(wantedPos.x-offsetX2,wantedPos.y-offsetY1,buttonWidht,buttonHeight),"");
		GUI.Box(new Rect(wantedPos.x-offsetX2,wantedPos.y+offsetY2,buttonWidht,buttonHeight),"");

		GUI.DrawTexture(new Rect(wantedPos.x-offsetX2,wantedPos.y-offsetY1,buttonWidht,buttonHeight) , textureUpgrade);
		if(GUI.Button(new Rect(wantedPos.x-offsetX2,wantedPos.y-offsetY1,buttonWidht,buttonHeight), "", new GUIStyle())) {
			enabled=false;
		}
		
		GUI.DrawTexture(new Rect(wantedPos.x-offsetX2,wantedPos.y+offsetY2,buttonWidht,buttonHeight) , textureSell);
		if(GUI.Button(new Rect(wantedPos.x-offsetX2,wantedPos.y+offsetY2,buttonWidht,buttonHeight), "", new GUIStyle())) {
			enabled=false;
		}
	}


}