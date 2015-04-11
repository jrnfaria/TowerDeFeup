using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public int money;
	private int health;
	public Text moneyText, healthText;
	private List<GameObject> enemies;

	// Use this for initialization
	void Start () {
		health = 20;
		moneyText.text = money.ToString();
		healthText.text = health.ToString();
		InvokeRepeating ("calcEnemies",0.05f,0.05f);
	}
	
	// Update is called once per frame
	void Update () {
		moneyText.text = money.ToString();
		healthText.text = health.ToString();
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
