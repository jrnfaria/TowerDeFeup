using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;

public class EnemySpawner : MonoBehaviour {

	private GameObject enemy;
	private int[][]enemyNo;
	private string[][]enemyType;
	private XmlReader xml;
	private int k=0, j=0, l=0;
	private GridLayoutBehaviour glb;

	// Use this for initialization
	void Start () {
		glb = GetComponent<GridLayoutBehaviour>();
		readLevel ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void SpawnEnemy(){
		if (l < enemyNo.Length) {//wave number
			if (k < enemyNo [l].Length) {//enemy type number
				if (j < enemyNo [l] [k]) {//enemy number
					j++;
					Instantiate (Resources.Load (enemyType [l] [k]), transform.position, Quaternion.identity);
				} else {
					k++;
					j = 0;
				}
			} else if (GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ().getEnemies ().Count == 0) {
				l++;
				k = 0;
			}
			Invoke ("SpawnEnemy", 0.5f);
		} else if (l == enemyNo.Length) {//victory
			glb.setLevel();
			readLevel();
			glb.read();
			GetComponent<GameController>().readMH();
			Debug.Log("level = " + glb.getLevel());
			destroyTowers();
			k=0;j=0;l=0;
		}
	}

	public void destroyTowers(){
		
		GameObject[]go = GameObject.FindGameObjectsWithTag("Tower");
		for(int i=0; i<go.Length;i++){
			Destroy(go[i]);
		}
	}

	public string getWaveNo(){
		return (l+1)+"/"+enemyNo.Length;
	}

	public void readLevel(){
		xml = this.GetComponent<XmlReader> ();

		try{
			xml.read("Level "+glb.getLevel());
		}catch (FileNotFoundException){
			if (l == enemyNo.Length)
				Application.LoadLevel(14);
		}


		enemyNo = new int[xml.container.waves.Count] [];
		enemyType = new string[xml.container.waves.Count] [];
		for (int h=0; h< xml.container.waves.Count; h++) {
			enemyNo[h] = new int[xml.container.waves[h].content.Count];
			enemyType[h] = new string[xml.container.waves[h].content.Count];
		}
		
		//get Type and quantity
		for (int h=0; h< enemyNo.Length; h++) {
			for (int i=0; i< enemyNo[h].Length; i++) {
				enemyType[h][i] = xml.container.waves [h].content [i].type;
				enemyNo[h][i] = xml.container.waves [h].content [i].quantity;
			}
		}

		Invoke ("SpawnEnemy", 0.5f);
	}
}
