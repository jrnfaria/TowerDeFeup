using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;


public class GridLayoutBehaviour : MonoBehaviour {
	
	public GameObject tile;
	public GameObject pathTile;
	public GameObject feup;
	private int tilesX;
	private int tilesY;
	private int level = 1;
	private GameObject feupBase;
	
	// Use this for initialization
	void Awake () {
		read ();
	}

	public void read(){
		try{
			this.GetComponent<XmlReader> ().read("Level "+level);
		}catch (FileNotFoundException){}

		Container container = this.GetComponent<XmlReader>().container;
		
		tilesX = container.tilesX;
		tilesY = container.tilesY;
		
		//end of read xml
		
		int offsetX=tilesX/2;
		int offsetY=tilesY/2;
		string name;
		
		for(int y = 0; y < tilesY; y++)
		{
			for(int x = 0; x < tilesX; x++)
			{
				name=getPath(x,y,container.paths);
				if(name=="Last"){
					Destroy (feupBase);
					feupBase = (GameObject)Instantiate(feup);
					feupBase.transform.position = new Vector3(x-offsetX,y-offsetY,0);
				}else if(name==""){
					GameObject obj = (GameObject)Instantiate(tile);
					obj.transform.position = new Vector3(x-offsetX,y-offsetY,0);
				}
			}
		}
		
		for (int i=0; i<container.paths.Count; i++) {
			
			GameObject obj = (GameObject)Instantiate(pathTile);
			obj.transform.position = new Vector3(container.paths[i].x-offsetX,container.paths[i].y-offsetY,0);
			obj.name="Point";
		}
	}
	
	
	string getPath(int x, int y,List<path> paths)
	{
		int i;
		for (i=0; i<paths.Count; i++) {
			if(paths[i].x==x&&paths[i].y==y)
				return "Point"+i;
			else if(paths[paths.Count-1].x==x && paths[paths.Count-1].y==y)
				return "Last";
		}
		return "";
	}
	
	
	// Update is called once per frame
	void Update () {
		
	}

	public int getLevel(){
		return level;
	}

	public void setLevel(){
		level++;
	}
}
