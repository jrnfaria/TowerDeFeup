using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	private int money;
	public GUIText moneyText;

	// Use this for initialization
	void Start () {
		money = 0;
		moneyText.text = "Money:"+money;
	}
	
	// Update is called once per frame
	void Update () {
		moneyText.text = "Money:"+money;
	}

	public void addMoney(int m)
	{
		money = m + money;
	}
}
