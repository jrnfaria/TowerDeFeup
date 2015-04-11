using UnityEngine;
using System.Collections;

public class UpgradeTowerGUI : MonoBehaviour {

	private Vector3 wantedPos;
	public Texture2D textureUpgrade;
	public Texture2D textureSell;

	public int money;

	private GameController gCtrl;

	//working with every tower
	private Tower towerSript;

	// Use this for initialization
	void Start () {
		wantedPos = Camera.main.WorldToScreenPoint(transform.position);
		wantedPos = new Vector3 (wantedPos.x, Screen.height-wantedPos.y , wantedPos.z);
		gCtrl = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
		towerSript=GetComponent<Tower>();
	}

	void OnGUI () {
		float rx = Screen.width / 1280.0f; //or whatever with do you want;
		float ry = Screen.height / 720.0f; //or whatever height do you want;
		
		float buttonWidht = 50 * rx;
		float buttonHeight = 50 * ry;

		float offsetY1 = 75 * ry;
		float offsetY2 = 25 * ry;

		float offsetX2 = 25 * rx;

		if (towerSript.getTowerLevel() < 3) {
			GUI.Box (new Rect (wantedPos.x - offsetX2, wantedPos.y - offsetY1, buttonWidht, buttonHeight), "");
			GUI.DrawTexture (new Rect (wantedPos.x - offsetX2, wantedPos.y - offsetY1, buttonWidht, buttonHeight), textureUpgrade);
			if (GUI.Button (new Rect (wantedPos.x - offsetX2, wantedPos.y - offsetY1, buttonWidht, buttonHeight), "", new GUIStyle ())) {
				if (gCtrl.money >= money) {
					towerSript.upgrade ();
					gCtrl.addMoney (-money);
				}
				enabled = false;
			}
		}

		GUI.Box(new Rect(wantedPos.x-offsetX2,wantedPos.y+offsetY2,buttonWidht,buttonHeight),"");
		GUI.DrawTexture(new Rect(wantedPos.x-offsetX2,wantedPos.y+offsetY2,buttonWidht,buttonHeight) , textureSell);
		if(GUI.Button(new Rect(wantedPos.x-offsetX2,wantedPos.y+offsetY2,buttonWidht,buttonHeight), "", new GUIStyle())) {
			transform.root.GetComponent<TileBehaviour>().SendMessage("setUsed",false);
			Destroy (transform.parent.gameObject);
			gCtrl.addMoney(money/2*towerSript.getTowerLevel());
			enabled=false;
		}
	}


}
