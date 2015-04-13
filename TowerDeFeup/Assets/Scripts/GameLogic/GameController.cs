using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public int money;
	public int health;
	public Texture2D moneyTexture, healthTexture;
	private Texture2D nextEnemy;
	private EnemySpawner enemyInfo;
	private List<GameObject> enemies;
	private bool isPaused=false;
	private string pauseText="Pause";

	// Use this for initialization
	void Start () {
		health = this.GetComponent<XmlReader> ().container.health;
		money = this.GetComponent<XmlReader> ().container.money;
		enemyInfo = GameObject.FindGameObjectWithTag ("GameController").GetComponent<EnemySpawner> ();
		InvokeRepeating ("calcEnemies",0.05f,0.05f);
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void readMH(){
		health = this.GetComponent<XmlReader> ().container.health;
		money = this.GetComponent<XmlReader> ().container.money;
	}

	void OnGUI () {
		float width=Screen.width/1366, height=Screen.height/597;

		GUI.Box (new Rect (10*width,10*height,100*width,50*height), new GUIContent(getSpaces(money), moneyTexture));
		GUI.Box (new Rect (10*width,70*height,100*width,50*height), new GUIContent(getSpaces(health), healthTexture));
		GUI.Box (new Rect (10*width,130*height,100*width,50*height), new GUIContent("Level\n"+GetComponent<GridLayoutBehaviour>().getLevel()));
		GUI.Box (new Rect (10*width,190*height,100*width,50*height), new GUIContent("Wave\n"+(enemyInfo.getWaveNo())));
		if (GUI.Button (new Rect (10 * width, 310 * height, 150 * width, 40 * height), new GUIContent (pauseText))) {
			if (isPaused) {
				Time.timeScale = 1.0f;
				pauseText="Pause";
				isPaused=false;
			} else {
				Time.timeScale = 0;
				pauseText="Continue";
				isPaused=true;
			}
		}
		if(GUI.Button (new Rect (10*width,360*height,150*width,40*height), new GUIContent ("Try again")))
			Application.LoadLevel(2);
		if(GUI.Button (new Rect (10*width,410*height,150*width,40*height), new GUIContent ("Give up")))
			Application.LoadLevel(0);
	}

	private string getSpaces(int value){
		int count = 0;
		string text="";
		int value2 = value;
		do{
			count = count + 1;
			value2 = value2 / 10;
		}while (value2 != 0);

		for (int i=0; i<5-count; i++) {
			text="0"+text;
		}
		return text+value;
	}

	public void setHealth(){
		health = health - 1;
	}

	public int getHealth(){
		return health;
	}

	public void addMoney(int m)
	{
		money = m + money;
	}


	void calcEnemies ()
	{
		enemies = new List<GameObject> ();
		
		foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy")) {
			enemies.Add (enemy);
		}
	}

	public List<GameObject> getEnemies()
	{
		return enemies;
	}
}
