using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	private int money;
	public GUIText moneyText;
	private List<GameObject> enemies;

	// Use this for initialization
	void Start () {
		money = 0;
		moneyText.text = "\n\n                  "+money;
		InvokeRepeating ("calcEnemies",0.05f,0.05f);
	}
	
	// Update is called once per frame
	void Update () {
		moneyText.text = "\n\n                  "+money;
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
