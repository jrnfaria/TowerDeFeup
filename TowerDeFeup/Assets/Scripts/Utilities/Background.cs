using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {
	
	public Texture background;
	
	void OnGUI(){
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), background);

		float bWidth=200*Screen.width/1366, bHeight=60*Screen.height/768;
		GUI.Button(new Rect(Screen.width/2-bWidth/2,350,bWidth,bHeight),"Play again");
		GUI.Button(new Rect(Screen.width/2-bWidth/2,420,bWidth,bHeight),"Go to menu");
	}
}
