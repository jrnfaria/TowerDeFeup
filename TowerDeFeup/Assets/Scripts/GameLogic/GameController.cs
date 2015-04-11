using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public int money;
	public int health;
	public Texture2D moneyTexture, healthTexture;
	private List<GameObject> enemies;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("calcEnemies",0.05f,0.05f);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnGUI () {
		GUI.Box (new Rect (10,10,100,50), new GUIContent(getSpaces(money), moneyTexture));
		GUI.Box (new Rect (10,70,100,50), new GUIContent(getSpaces(health), healthTexture));
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
