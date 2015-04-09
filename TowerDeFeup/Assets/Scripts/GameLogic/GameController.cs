using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	private int money;
	private int health;
	public GUIText infoText;
	private List<GameObject> enemies;

	// Use this for initialization
	void Start () {
		health = 20;
		money = 0;
		infoText.text = "\n\n                  "+money+"\n\n\n                  "+health;
		InvokeRepeating ("calcEnemies",0.05f,0.05f);
	}
	
	// Update is called once per frame
	void Update () {
		infoText.text = "\n\n                  "+money+"\n\n\n                  "+health;
	}

	public void setHealth(){
		health = health - 1;
		if (health == 0) {
			
		}
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
