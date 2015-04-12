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

	//audio
	public AudioSource audio;

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
		
		float buttonWidth = 30 * rx;
		float buttonHeight = 30 * ry;

		float boxWidth = 50 * rx;
		float boxHeight = 50 * ry;

		float offsetY1 = 75 * ry;
		float offsetY2 = 25 * ry;

		float offsetX2 = 25 * rx;

		if (towerSript.getTowerLevel() < 3) {
			GUI.Box (new Rect (wantedPos.x - offsetX2, wantedPos.y - offsetY1, boxWidth, boxHeight), "");
			GUI.Label(new Rect(15 * rx+wantedPos.x-offsetX2,30*ry+wantedPos.y-offsetY1,50*rx,20*ry),money.ToString());
			GUI.DrawTexture (new Rect (10*rx+wantedPos.x - offsetX2, wantedPos.y - offsetY1, buttonWidth, buttonHeight), textureUpgrade);
			if (GUI.Button (new Rect (wantedPos.x - offsetX2, wantedPos.y - offsetY1, boxWidth, boxHeight), "", new GUIStyle ())) {
				if (gCtrl.money >= money) {
					towerSript.upgrade ();
					gCtrl.addMoney (-money);
					audio.Play();
				}
				enabled = false;
			}
		}

		GUI.Box(new Rect(wantedPos.x-offsetX2,wantedPos.y+offsetY2,boxWidth,boxHeight),"");
		GUI.DrawTexture(new Rect(10*rx+wantedPos.x-offsetX2,wantedPos.y+offsetY2,buttonWidth,buttonHeight) , textureSell);
		GUI.Label(new Rect(15 * rx+wantedPos.x-offsetX2,30*ry+wantedPos.y+offsetY2,50*rx,20*ry),(money+money/2*(towerSript.getTowerLevel()-1)).ToString());
		if(GUI.Button(new Rect(wantedPos.x-offsetX2,wantedPos.y+offsetY2,boxWidth,boxHeight), "", new GUIStyle())) {
			transform.root.GetComponent<TileBehaviour>().SendMessage("setUsed",false);
			Destroy (transform.parent.gameObject);
			gCtrl.addMoney(money+money/2*(towerSript.getTowerLevel()-1));
			enabled=false;
		}
	}


}
