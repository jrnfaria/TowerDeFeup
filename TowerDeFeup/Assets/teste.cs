using UnityEngine;
using System.Collections;
using ProtoTurtle.BitmapDrawing;

public class teste : MonoBehaviour {
	
	void Start () {
		Material material = GetComponent<Renderer>().material;
		Texture2D texture = new Texture2D(512,512, TextureFormat.RGB24, false);
		texture.wrapMode = TextureWrapMode.Clamp;
		material.SetTexture(0, texture);

		texture.DrawCircle(256, 256, 256, Color.red);

		texture.Apply ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
