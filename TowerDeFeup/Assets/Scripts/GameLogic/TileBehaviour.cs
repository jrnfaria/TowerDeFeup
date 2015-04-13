﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileBehaviour : MonoBehaviour {

	public GameObject tower1;
	public GameObject tower2;
	public GameObject tower3;
	public GameObject tower4;
	public bool used=false;
	private PlaceTowerGUI gui;
	private int towerPlacement;
	private GameObject tower;

	// Use this for initialization
	void Start () {
		gui = GetComponent<PlaceTowerGUI>();
		gui.enabled = false;
		towerPlacement = 0;

	}
	
	void OnMouseOver(){

	if (Input.GetMouseButtonDown (0)&&!used) {
			closeInterfaces ();
			gui.enabled = true;
		}
	}

	public void closeInterfaces()
	{
		GameObject[] tiles = GameObject.FindGameObjectsWithTag ("Tile");
		for(int i=0;i<tiles.Length;i++ )
		{
			tiles[i].GetComponent<PlaceTowerGUI>().enabled=false;
		}
		
		GameObject[] towers = GameObject.FindGameObjectsWithTag ("Tower");
		for(int i=0;i<towers.Length;i++ )
		{
			towers[i].GetComponent<UpgradeTowerGUI>().enabled=false;
		}
	}

	public void setUsed(bool b)
	{
		used = b;
		towerPlacement = 0;
	}

	public void setTowerPlacement(int t)
	{
		towerPlacement = t;
	}

	// Update is called once per frame
	void Update () {
		if (towerPlacement == 1 && !used) {
			tower=Instantiate (tower1, transform.position, Quaternion.identity) as GameObject;
			tower.transform.parent=transform;
			used=true;
			GetComponent<Collider2D>().enabled=false;
		}
		else if (towerPlacement == 2 && !used) {
			tower=Instantiate (tower2, transform.position, Quaternion.identity)as GameObject;
			tower.transform.parent=transform;
			used=true;
			GetComponent<Collider2D>().enabled=false;
		}
		else if (towerPlacement == 3 && !used) {
			tower=Instantiate (tower3, transform.position, Quaternion.identity)as GameObject;
			tower.transform.parent=transform;
			used=true;
			GetComponent<Collider2D>().enabled=false;
		}
		else if (towerPlacement == 4 && !used) {
			tower=Instantiate (tower4, transform.position, Quaternion.identity)as GameObject;
			tower.transform.parent=transform;
			used=true;
			GetComponent<Collider2D>().enabled=false;
		}
	}
}
