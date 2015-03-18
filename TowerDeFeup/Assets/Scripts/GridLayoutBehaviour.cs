using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GridLayoutBehaviour : MonoBehaviour {

	public GameObject tile;
	public GameObject pathTile;
	private int tilesX;
	private int tilesY;

	// Use this for initialization
	void Start () {

		Container container = this.GetComponent<XmlReader>().container;

		tilesX = container.tilesX;
		tilesY = container.tilesY;

		//end of read xml

		int offsetX=tilesX/2;
		int offsetY=tilesY/2;
		string name;

		for(int x = 0; x < tilesX; x++)
		{
			for(int y = 0; y < tilesY; y++)
			{
				name=getPath(x,y,container.paths);
				if(name!="")
				{
					GameObject obj = (GameObject)Instantiate(pathTile);
					obj.transform.position = new Vector3(x-offsetX,y-offsetY,0);
					obj.name=name;
				}
				else{
				GameObject obj = (GameObject)Instantiate(tile);
				obj.transform.position = new Vector3(x-offsetX,y-offsetY,0);
				}
			}
		}
	}


	string getPath(int x, int y,List<path> paths)
	{
		int i;
		for (i=0; i<paths.Count; i++) {
			if(paths[i].x==x&&paths[i].y==y)
				return "Point"+i;
		}
		return "";
	}


	// Update is called once per frame
	void Update () {
	
	}
}
