using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

//read state xml;

public class path
{
	public int x;
	public int y;
	
}

public class enemy
{
	[XmlAttribute("type")]
	public string type;
	
	public int quantity;
}

[XmlRoot("waves")]
public class wave
{
	[XmlArray("content")]
	[XmlArrayItem("enemy")]
	public List<enemy> content = new List<enemy>();
}

[XmlRoot("game")]
public class Container
{
	public int tilesX;

	public int tilesY;
	
	[XmlArray("path")]
	[XmlArrayItem("tile")]
	public List<path> paths = new List<path>();

	[XmlArray("waves")]
	[XmlArrayItem("wave")]
	public List<wave> waves = new List<wave>();
}

public class XmlReader : MonoBehaviour {
	
	public Container container;

	void Awake () {

		//read xml
		var serializer = new XmlSerializer (typeof(Container));
		var stream = new FileStream (Application.dataPath + "/Levels/level1.xml", FileMode.Open);
		container = serializer.Deserialize (stream) as Container;
		stream.Close ();

		Debug.Log (container.waves.Count);
		Debug.Log (container.waves[0].content.Count);

	}


	//end of state xml


	// Update is called once per frame
	void Update () {
	
	}
}
